import os
import json
import feedparser
import requests
from groq import Groq
from supabase import create_client
from dotenv import load_dotenv
from datetime import datetime

load_dotenv()

supabase = create_client(os.getenv("SUPABASE_URL"), os.getenv("SUPABASE_KEY"))
groq_client = Groq(api_key=os.getenv("GROQ_API_KEY"))

RSS_FEEDS = [
    ("BBC World", "http://feeds.bbci.co.uk/news/world/rss.xml"),
    ("Al Jazeera", "https://www.aljazeera.com/xml/rss/all.xml"),
    ("Telex", "https://telex.hu/rss"),
    ("444", "https://444.hu/feed"),
]

def fetch_rss():
    articles = []
    for source, url in RSS_FEEDS:
        try:
            feed = feedparser.parse(url)
            for entry in feed.entries[:8]:
                articles.append({
                    "title": entry.get("title", ""),
                    "summary": entry.get("summary", ""),
                    "url": entry.get("link", ""),
                    "source": source,
                    "published_at": str(datetime.now())
                })
            print(f"Fetched {len(feed.entries[:8])} articles from {source}")
        except Exception as e:
            print(f"Error fetching {source}: {e}")
    return articles

def fetch_newsapi():
    articles = []
    try:
        url = "https://newsapi.org/v2/everything"
        params = {
            "q": "Hungary OR Orban OR Budapest OR forint",
            "language": "en",
            "sortBy": "publishedAt",
            "pageSize": 20,
            "apiKey": os.getenv("NEWSAPI_KEY")
        }
        res = requests.get(url, params=params)
        data = res.json()
        for item in data.get("articles", []):
            articles.append({
                "title": item.get("title", ""),
                "summary": item.get("description", ""),
                "url": item.get("url", ""),
                "source": item.get("source", {}).get("name", "NewsAPI"),
                "published_at": item.get("publishedAt", str(datetime.now()))
            })
        print(f"Fetched {len(articles)} articles from NewsAPI")
    except Exception as e:
        print(f"Error fetching NewsAPI: {e}")
    return articles

def analyze_article(article):
    prompt = f"""
You are an analyst specializing in Hungary, its politics, economy, and effects on young people.

Analyze this news article and return ONLY a valid JSON object, no extra text, no markdown, no backticks.

Title: {article['title']}
Summary: {article['summary']}

Return exactly this JSON structure:
{{
  "sentiment_score": 0.0,
  "topics": ["politics"],
  "affects_hungary": true,
  "hungary_impact": "one sentence explanation",
  "warning_level": "low"
}}

Rules:
- sentiment_score is a float between -1.0 and 1.0
- topics is an array chosen from: politics, economy, youth, EU, migration, education, housing, energy, media, corruption
- affects_hungary is true or false
- warning_level is exactly one of: low, medium, high
"""
    try:
        response = groq_client.chat.completions.create(
            model="llama-3.3-70b-versatile",
            messages=[{"role": "user", "content": prompt}],
            temperature=0.1
        )
        text = response.choices[0].message.content.strip()
        text = text.replace("```json", "").replace("```", "").strip()
        return json.loads(text)
    except Exception as e:
        print(f"Error analyzing article: {e}")
        return None

def already_exists(url):
    try:
        result = supabase.table("articles").select("id").eq("url", url).execute()
        return len(result.data) > 0
    except:
        return False

def save_article(article, analysis):
    try:
        supabase.table("articles").insert({
            "title": article["title"],
            "source": article["source"],
            "url": article["url"],
            "published_at": article["published_at"],
            "summary": article["summary"],
            "sentiment_score": analysis["sentiment_score"],
            "topics": analysis["topics"],
            "affects_hungary": analysis["affects_hungary"],
            "hungary_impact": analysis["hungary_impact"],
            "warning_level": analysis["warning_level"]
        }).execute()
        print(f"Saved: {article['title'][:60]}...")
    except Exception as e:
        print(f"Error saving: {e}")

def main():
    print("Starting news collection...")
    all_articles = fetch_rss() + fetch_newsapi()
    print(f"Total articles fetched: {len(all_articles)}")

    saved = 0
    skipped = 0

    for article in all_articles:
        if not article["title"] or not article["url"]:
            continue
        if already_exists(article["url"]):
            skipped += 1
            continue
        analysis = analyze_article(article)
        if analysis:
            save_article(article, analysis)
            saved += 1

    print(f"Done! Saved: {saved} | Skipped duplicates: {skipped}")

if __name__ == "__main__":
    main()