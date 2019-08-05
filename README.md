# Rebus.Ceras

[![install from nuget](https://img.shields.io/nuget/v/Rebus.Ceras.svg?style=flat-square)](https://www.nuget.org/packages/Rebus.Ceras)

Provides a [Ceras](https://github.com/rikimaru0345/Ceras) serializer for [Rebus](https://github.com/rebus-org/Rebus).

![](https://raw.githubusercontent.com/rebus-org/Rebus/master/artwork/little_rebusbus2_copy-200x200.png)

---

It's just

```csharp
Configure.With(...)
    .(...)
    .Serialization(s => s.UseCeras())
    .Start();
```

and then Rebus is using Ceras.

The `rbs2-content-type` header will be populated by the value `application/x-ceras`.