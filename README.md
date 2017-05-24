# TrumpTwitter

A simple to use console application for exploring Trump's Twitter feed.

## Overview
**TrumpTwitter** exposes the ability for anyone to search through Trumps tweets and view info about where posts come from.

## Getting Started
Download and install TrumpTwitter from [https://github.com/jacob-ebey/TrumpTwitter/raw/master/TrumpTwitter/publish/TrumpTwitter.1.0.exe](https://github.com/jacob-ebey/TrumpTwitter/raw/master/TrumpTwitter/publish/TrumpTwitter.1.0.exe).

I recommend setting [VSCode](https://code.visualstudio.com/Download) as your default .json editor. When using the search command, the results will be opened in your default
text editor. If the editor supports file refreshing like [VSCode](https://code.visualstudio.com/Download) does, the file will be hot updated in the editor window.

## View some metadata
The only metadata at this time is the source of Trumps tweets. For example:
```
Command (help): meta
```

will give the console output similar to: 
```
Sources:
        'Twitter for iPhone' tweeted from 1500 times
        'Twitter Ads' tweeted from 23 times
        'Media Studio' tweeted from 2 times
        'Twitter for Android' tweeted from 1268 times
        'Twitter Web Client' tweeted from 196 times
        'Periscope' tweeted from 1 times
        'Twitter for iPad' tweeted from 20 times
        'Instagram' tweeted from 1 times
```

## Search Trump's tweets for keywords

You can search for multiple keywords by separating them with a `|` character. For example:
```
Command (help): search russia|putin
```

will give console output similar to:
```
Found 69 tweets since Apr 30 2016 containing 'russia' or 'putin'.
```

and open the results in your default .json editor.

## Viewing tweets

You can view a specific tweet by ID and retrieve the immidiate tweets before or after. For example:
```
Command (help): view 846533818811080704
``` 

will give the console output:
```json
{
  "Id": 846533818811080704,
  "FullText": "Why isn't the House Intelligence Committee looking into the Bill &amp; Hillary deal that allowed big Uranium to go to Russia, Russian speech....",
  "Source": "<a href=\"http://twitter.com/download/iphone\" rel=\"nofollow\">Twitter for iPhone</a>",
  "CreatedAt": "2017-03-27T18:26:04-07:00",
  "Text": "Why isn't the House Intelligence Committee looking into the Bill &amp; Hillary deal that allowed big Uranium to go to Russia, Russian speech....",
  "RetweetCount": 26611,
  "FavoriteCount": 89759,
  "Language": 42,
  "PublishedTweetLength": 144,
  "TweetLocalCreationDate": "2017-05-23T22:33:28.8434792-07:00",
  "IsTweetPublished": true,
  "Url": "https://twitter.com/realDonaldTrump/status/846533818811080704",
  "IdStr": "846533818811080704"
}
```

But if you want to view the next tweet, you can do:
```
Command (help): view 846533818811080704 1
```

and that will give the console output:
```json
{
  "Id": 846533818811080704,
  "FullText": "Why isn't the House Intelligence Committee looking into the Bill &amp; Hillary deal that allowed big Uranium to go to Russia, Russian speech....",
  "Source": "<a href=\"http://twitter.com/download/iphone\" rel=\"nofollow\">Twitter for iPhone</a>",
  "CreatedAt": "2017-03-27T18:26:04-07:00",
  "Text": "Why isn't the House Intelligence Committee looking into the Bill &amp; Hillary deal that allowed big Uranium to go to Russia, Russian speech....",
  "RetweetCount": 26611,
  "FavoriteCount": 89759,
  "Language": 42,
  "PublishedTweetLength": 144,
  "TweetLocalCreationDate": "2017-05-23T22:33:28.8434792-07:00",
  "IsTweetPublished": true,
  "Url": "https://twitter.com/realDonaldTrump/status/846533818811080704",
  "IdStr": "846533818811080704"
}
{
  "Id": 846536212362018816,
  "FullText": "...money to Bill, the Hillary Russian \"reset,\" praise of Russia by Hillary, or Podesta Russian Company. Trump Russia story is a hoax. #MAGA!",
  "Source": "<a href=\"http://twitter.com/download/iphone\" rel=\"nofollow\">Twitter for iPhone</a>",
  "CreatedAt": "2017-03-27T18:35:35-07:00",
  "Text": "...money to Bill, the Hillary Russian \"reset,\" praise of Russia by Hillary, or Podesta Russian Company. Trump Russia story is a hoax. #MAGA!",
  "RetweetCount": 19296,
  "FavoriteCount": 69890,
  "Language": 42,
  "PublishedTweetLength": 140,
  "TweetLocalCreationDate": "2017-05-23T22:33:28.8434792-07:00",
  "IsTweetPublished": true,
  "Url": "https://twitter.com/realDonaldTrump/status/846536212362018816",
  "IdStr": "846536212362018816"
}
```

To view a previous tweet:
```
view 863002719400976384 -1
```

and that will give the output:
```json
{
  "Id": 863000553265270786,
  "FullText": "As a very active President with lots of things happening, it is not possible for my surrogates to stand at podium with perfect accuracy!....",
  "Source": "<a href=\"http://twitter.com/download/iphone\" rel=\"nofollow\">Twitter for iPhone</a>",
  "CreatedAt": "2017-05-12T04:59:00-07:00",
  "Text": "As a very active President with lots of things happening, it is not possible for my surrogates to stand at podium with perfect accuracy!....",
  "RetweetCount": 13294,
  "FavoriteCount": 62621,
  "Language": 42,
  "PublishedTweetLength": 140,
  "TweetLocalCreationDate": "2017-05-23T22:33:27.7124157-07:00",
  "IsTweetPublished": true,
  "Url": "https://twitter.com/realDonaldTrump/status/863000553265270786",
  "IdStr": "863000553265270786"
}
{
  "Id": 863002719400976384,
  "FullText": "...Maybe the best thing to do would be to cancel all future \"press briefings\" and hand out written responses for the sake of accuracy???",
  "Source": "<a href=\"http://twitter.com/download/iphone\" rel=\"nofollow\">Twitter for iPhone</a>",
  "CreatedAt": "2017-05-12T05:07:36-07:00",
  "Text": "...Maybe the best thing to do would be to cancel all future \"press briefings\" and hand out written responses for the sake of accuracy???",
  "RetweetCount": 18830,
  "FavoriteCount": 81644,
  "Language": 42,
  "PublishedTweetLength": 136,
  "TweetLocalCreationDate": "2017-05-23T22:33:27.7124157-07:00",
  "IsTweetPublished": true,
  "Url": "https://twitter.com/realDonaldTrump/status/863002719400976384",
  "IdStr": "863002719400976384"
}
```