# Cross-site scripting
In any web application, there are three main components: HTML, CSS, and JavaScript. Cross-Site Scripting (XSS) vulnerabilities can occur in any of these components. Each code segment consists of a string of characters interpreted by their respective interpreters. An XSS attack occurs when a user is able to inject a "malicious string" into an interpreter through "your server", which is then executed to perform undesirable actions on the victim's browser.

## "Malicious String"? "Your Server"?
Let's clarify the terms mentioned. First, let's set up a scenario:

On the backend, there are two endpoints: a POST method endpoint for adding a post, where authenticated users can submit a string of characters to be stored in the database, and a GET endpoint for retrieving a specific post from the database.

On the frontend, users retrieve and view posts, including those published by other users.

Now, what could go wrong here?

Consider this situation: a user named Oscar submits a post that resembles HTML code:
```HTML
<script>alert('Hacked!')</script>
```
When other users call the GET endpoint to view Oscar's post, they receive a popup message saying "Hacked!". Why does this happen?

The data retrieved from the server is parsed by the browser's HTML parser. If the data is not properly encoded, the browser may execute Oscar's post as code. This vulnerability is what we refer to as Cross-Site Scripting (XSS).


