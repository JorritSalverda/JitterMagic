# JitterMagic

A c# library to add jitter to cache durations and retry intervals to increase entropy in your system and prevent thundering herds

[![Build Status .NET](https://img.shields.io/appveyor/ci/JorritSalverda/JitterMagic.svg)](https://ci.appveyor.com/project/JorritSalverda/jittermagic/)
[![Build Status Mono](https://img.shields.io/travis/JorritSalverda/JitterMagic.svg)](https://travis-ci.org/JorritSalverda/JitterMagic/)
[![NuGet downloads](https://img.shields.io/nuget/dt/JitterMagic.svg)](https://www.nuget.org/packages/JitterMagic)
[![Version](https://img.shields.io/nuget/v/JitterMagic.svg)](https://www.nuget.org/packages/JitterMagic)
[![Issues](https://img.shields.io/github/issues/JorritSalverda/JitterMagic.svg)](https://github.com/JorritSalverda/JitterMagic/issues)
[![License](https://img.shields.io/github/license/JorritSalverda/JitterMagic.svg)](https://github.com/JorritSalverda/JitterMagic/blob/master/LICENSE)

Why?
--------------------------------
The library is inspired by [YouTube's strategy to add entropy](http://highscalability.com/blog/2012/4/17/youtube-strategy-adding-jitter-isnt-a-bug.html) to large systems by adding randomness to cache expiry durations

Usage
--------------------------------
Use it with either the default percentage of 25

```csharp
int cacheDuration = Jitter.Apply(1000);
```

or by supplying a percentage yourself

```csharp
int cacheDuration = Jitter.Apply(1000, 50);
```

Also works for doubles

```csharp
double cacheDuration = Jitter.Apply(1000D);
```

or by supplying a percentage yourself

```csharp
double cacheDuration = Jitter.Apply(1000D, 50);
```

### Changing defaults

The following defaults are used and can be changed by using the following code with different values

```csharp
Jitter.DefaultPercentage = 25;
```

Get it
--------------------------------
First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [JitterMagic](https://www.nuget.org/packages/JitterMagic/) from the package manager console:

    PM> Install-Package JitterMagic

JitterMagic is Copyright &copy; 2015 [Jorrit Salverda](http://blog.jorritsalverda.com/) and other contributors under the [MIT license](https://github.com/JorritSalverda/JitterMagic/blob/master/LICENSE).