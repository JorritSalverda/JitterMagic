# JitterMagic

A c# library to add jitter to cache durations and retry intervals to increase entropy in your system and prevent thundering herds

[![Build Status .NET](https://ci.appveyor.com/api/projects/status/github/JorritSalverda/JitterMagic?svg=true)](https://ci.appveyor.com/project/JorritSalverda/JitterMagic/)
[![Build Status Mono](https://api.travis-ci.org/JorritSalverda/JitterMagic.svg)](https://travis-ci.org/JorritSalverda/JitterMagic/)
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

### Non-static usage

If you wish to be able to inject it - for example for having different percentages in different places - you can use the JitterInstance class:

```csharp
IJitterInstance instance = new JitterInstance(25);
```

This interface and class only has the Apply methods without percentage, because you provide that during construction.

So it provides the following function for integers

```csharp
int cacheDuration = instance.Apply(1000);
```

And also works for doubles

```csharp
double cacheDuration = instance.Apply(1000D);
```

Get it
--------------------------------
First, [install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). Then, install [JitterMagic](https://www.nuget.org/packages/JitterMagic/) from the package manager console:

    PM> Install-Package JitterMagic

JitterMagic is Copyright &copy; 2015 [Jorrit Salverda](http://blog.jorritsalverda.com/) and other contributors under the [MIT license](https://github.com/JorritSalverda/JitterMagic/blob/master/LICENSE).
