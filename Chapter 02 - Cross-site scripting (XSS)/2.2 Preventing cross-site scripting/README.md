# How to pervent XSS Attacks?
we had a glimpse of what a XSS attack looks like, then what should we do to pervent it?

## String Context
To pervent XSS, we need first to understand our string context. then what is it? 

In our web applications most of strings will be processed by different components, and here is the problems begin.

Each component will have its own special characters so for each component we will have a different context for the same string! It may still be obecure but I beleive the HTML example we will talk about will clearfy everything.

## Perventing HTML XSS
For example, if it's an html parser then you need to make sure that our string doesn't have any HTML syntax (special characters that has a special meaning for the parser instead of an ordinary text).
Encoding in the case of HTML will be instead of using HTML special characters like `< , > , " , ' , &`. We replace it with what we call HTML entites, which are the text representation of these special characters. the following is all the HTML special characters and their corresponding HTML entites.

 |Special character | HTML Entity |   
 |------ |------|
 |< | \&lt;|      
 |> | \&gt;|        
 |" | \&quot; or \&#34; or \&#x22;|
 |' | \&apos; or \&#39; or \&#x27;|
 |& | \&amp;|

## ASP.NET Core Specific
Wheather you are using Razor, or MVC. when you use the @ directive to add text to your HTML page the encoding is done by default no further encoding is needed. But in case you are stuck in a stuation where you want to encode the string properly so that it can be parsed as intended by the HTML parser then use The `System.Text.Encodings.Web` namespace contains the `HtmlEncoder` and `JavaScriptEncoder` classes
```csharp
var encoded = HtmlEncoder.Default.Encode(inputString);
```
