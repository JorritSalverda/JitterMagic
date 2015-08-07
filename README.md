# JitterMagic

What is JitterMagic?
--------------------------------
A c# library to add jitter to cache durations or any other values

The library is inspired by [YouTube's strategy to add entropy](http://highscalability.com/blog/2012/4/17/youtube-strategy-adding-jitter-isnt-a-bug.html) to large systems by adding randomness to cache expiry durations and other intervals

How do I use JitterMagic?
--------------------------------
Use it with either the default percentage of 25

```csharp
int cacheDuration = JitterMagic.ApplyJitter(1000);
```

or by supplying a percentage yourself

```csharp
int cacheDuration = JitterMagic.ApplyJitter(1000, 50);
```

Also works for doubles

```csharp
double cacheDuration = JitterMagic.ApplyJitter(1000D);
```

or by supplying a percentage yourself

```csharp
double cacheDuration = JitterMagic.ApplyJitter(1000D, 50);
```

### Changing defaults

The default percentages used by the smallest methods use the static JitterMagic.DefaultPercentage property. You can change it as follows

```csharp
JitterMagic.DefaultPercentage = 50;
```

Where can I get it?
--------------------------------
First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [JitterMagic](https://www.nuget.org/packages/JitterMagic/) from the package manager console:

    PM> Install-Package JitterMagic

JitterMagic is Copyright &copy; 2015 [Jorrit Salverda](http://blog.jorritsalverda.com/) and other contributors under the [MIT license](LICENSE.txt).