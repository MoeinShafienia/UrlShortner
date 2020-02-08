# Url Shortner

This is a simple Url shortner app (like Bitly) written in .Net Core 3.1

### Prerequisites

[.Net Core SDK](https://docs.microsoft.com/en-us/dotnet/core/install)

###Download the project

```
git clone https://github.com/MoeinShafienia/UrlShortner.git
cd UrlShortner/src
```

### Installing

- After you clone the project into your local system, you need to handle migrations part, don't worry if you have no knowledge about migrations(It's a part of EntityFrameworkCore), you need only to execute these commands only:
```
dotnet tool install --global dotnet-ef
dotnet ef migrations add Booking.AppDbContext
dotnet ef database update
```
- Now you can run the project:
```
dotnet run
```

## How To Use

### send a long url and get a short one
For this purposr we need to send a post request to server with longurl as a key/value entity of Json and the server will return a json containing both LongUrl and generated ShortUrl, For example:
```
curl -i -d '{"LongUrl":"https://google.com", "ShortUrl"=""}' -H "Content-Type: application/json" -X POST http://localhost:5000/urls
```
This command send a post request to server (-X POST) run in address of http://localhost:5000/urls (contains port number and route address) with LongUrl of "https://google.com" , and the response will be for example:
```
{"LongUrl":"https://www.google.com", "ShortUrl"="asufhmwo"}
```

### Redirect to a Url using a short url that you created before
Assume that you have a shortUrl and wanna to use it to go to the main page the LongUrl represent of, you have to use below command:
```
curl -i localhost:5000/Redirect/<ShortUrl>
```
So the server search for Short in the database and if it exist, automaticly redirect to it and if not return 404 status code, let's use generated Shorturl we receive from server in previous section:

## Built With

* [.NET Core](https://dotnet.microsoft.com/) - The web framework used
