# DomainObjects
The base-classes for DDDomain objects (Entities, Value-Types, and Aggregates)

The tactical bit of Domain-driven design describes value-types, entities, and aggregates. A couple of rules apply:


* Compare Value-types by their values
* Entities have an ID
* Aggregates have an ID
* Compare Entities and aggregates by their ids
* Aggregates reference other entities by id

To be able to do so, requires some code. Hence this repository.

## This package is available on NuGet

```bash 
Install-Package DomainDrivenDesign.DomainObjects
```

## How to create a value-type

This package contains a base-class for a value type. It supports:

* Comparing value types by the values it contains using .Equals(x), == and !=
* Converting it to a string using the ToString() method
* Sorting lists of values

Create a value type by implementing the `ValueType<T>` class, for example:

```csharp
public class Euro : Value<double>
{
    public static Euro Create(double value)
    {
        return new Euro(value);
    }

    private Euro(double value) : base(value)
    {
    }

    // Add the methods and operators you need here
}
```


How to use it:
```csharp
var a = Euro.Create(3.5f);
var b = Euro.Create(3.5f);

if(a == b) // This works out of the box
{
    Console.WriteLine("Eureka!");
}
```

## How to create a value-type with multiple values:

Create it by implementing the `ValueType<T1, T2, etc.>` class, for example:

```csharp
public class ZipCode : Value<int, string>
{
    private int _postalCode;
    private string _state;

    public static ZipCode Create(int postalCode, string state)
    {
        return new ZipCode(postalCode, state);
    }

    private ZipCode(int postalCode, string state) : base(postalCode, state)
    {
        _postalCode = postalCode;
        _state = state ?? throw new ArgumentNullException(nameof(state));
    }

    // Add the methods and operators you need here

    public override string ToString()
    {
        return $"{_postalCode} ${_state}";
    }
}
```

## How to create a numeric or a comparable type

Some values can be greater than and may need to be sorted. Assume you want to find the cheapest product. You'll need to sort by price. Prices are in Euro. Deriving the Euro class from `ComparableValue<T>` instead of `Value<T>` allows sorting and comparing:

```csharp
public class Euro : ComparableValue<double>
{
    public static Euro Create(double value)
    {
        return new Euro(value);
    }

    private Euro(double value) : base(value)
    {
    }

    // Add the methods and operators you need here
}
```

Now may be used like this:

``` csharp
var cheap = Euro.Create(1);
var expensive = Euro.Create(100000);

if(cheap < expensive)
{
    Console.WriteLine("That makes sense..");
}
```

Note that the class is called NumericValue. In most cases it's used with numbers. But it does not explicitly require a number. It requires the type parameter to derive from IComparable<T>.

## How to create an entity

This package contains a base-class for a entities. It supports:

* Comparing entities by using .Equals(x), == and !=
* Ids

Create an entity by implementing the `Entity<T>` base-class. It provides a public property called ID on every entity. Always construct an entity with an Id. Entities are more than just an Id. Add the properties you need to the constructor of the entity. Don't pass it to the base class. Example:

```csharp
public class Order : Entity<Order>
{
    public Euro Price { get; }

    // Don't forget to either give the class a public constructor
    // or add a factory method to instantiate an instance of the class..
    public Order(Id<Order> id, Euro price) : base(id)
    {
        Price = price;
    }
}
```

Use it like this:

```csharp
var id = Id<Order>.New();
var price = Euro.Create(3.5f);

var order = new Order(id, price);
Console.WriteLine(order.Id);
Console.WriteLine(order.Price);
```

## How to create an aggregate

This package contains a base-class for a entities. It supports:

* Comparing entities by using .Equals(x), == and !=
* Ids

Create an aggregate by implementing the `Aggregate<T>` base-class. It provides a public property called ID on every aggregate. Always construct an entity with an Id. Aggregates are more than just an Id. Add the properties you need to the constructor of the aggregate. Don't pass it to the base class. Example:

```csharp
public class OrderAggregateRoot : Aggregate<OrderAggregateRoot>
{
    public Euro Price { get; }
    public Id<Order> OrderId { get; }

    public OrderAggregateRoot(Id<OrderAggregateRoot> id, Id<Order> orderId, Euro price) : base(id)
    {
        OrderId = orderId;
        Price = price;
    }
}
```

Use it like this:

```csharp
var id = Id<OrderAggregateRoot>.New();
var orderId = Id<Order>.Create(new Guid("6001300f-8c49-402a-9545-027c8917557d"));
var price = Euro.Create(3.5f);

var order = new OrderAggregateRoot(id, orderId, price);
Console.WriteLine(order.Id);
Console.WriteLine(order.OrderId);
Console.WriteLine(order.Price);
```

## See it in action!

Use this repository as a reference. See how to use the DomainDrivenDesign.DomainObjects NuGet package [in this solution](https://github.com/appie2go/steal-this-code), in this [project](https://github.com/appie2go/steal-this-code/tree/master/Source/Dispatching).