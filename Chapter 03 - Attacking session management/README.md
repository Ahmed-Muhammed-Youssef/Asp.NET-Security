# Session Management Attack
HTTP is stateless so the most common way to store user's data is cookies to allow a 'session'. Before we go through what is session management, let's first understand what cookies are.

# Cookies
a piece of data sent by the server to the client (e.g his profile picture url, his public ID in the database and so on), which the user can send back to the server with other requests. which allows both the server and the client to share a state.

## How cookies are set
 When the client send a request to the server, the server can sendback a response with a 'set-cookie' header, for example:

 ``` powershell
 Set-Cookie: session-id=1234567; max-age=86400; domain=example.com; path=/;
 ```

 If The session expiration date is not set, the browser deletes it when closed.
the HTTP response can include multiple Set-Cookie headers
``` powershell
Set-Cookie: session-token=abcdef;
Set-Cookie: session-id=1234567;
```

## How to set and get cookies in ASP.NET Core
First, you create the cookie as the following, then you need to add it to the response.
```c#
var cookie = new CookieHeaderValue("session-id", "12345");
cookie.Expires = DateTimeOffset.Now.AddDays(1);
cookie.Domain = Request.RequestUri.Host;
cookie.Path = "/";
```
Getting the response cookie
```csharp
CookieHeaderValue cookie = Request.Headers.GetCookies("session-id").FirstOrDefault();
if (cookie != null)
{
    sessionId = cookie["session-id"].Value;
}
```