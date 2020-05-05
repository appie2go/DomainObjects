# DomainObjects
The base-classes for DDDomain objects (Entities, ValueTypes and aggregates)

The tactical bit of Domain driven design describes value-types, entities and aggregates. A couple of rules apply:

* Value-types are compared by their values
* Entities have an Id
* Aggregates have an Id
* Entities and aggregates are compared by their Id
* Aggregates reference other entities by their Id

To be able to do so, rquires some code. Hence this repository.

## This package is available on NuGet

```bash 
Install-Package DomainDrivenDesign.DomainObjects -Version 0.0.8 
```

## How to create a value-type

This package contains a  base-class for a value type. It supports:

* Comparing value types by the values it contains using .Equals(x), == and !=
* Converting it to a string using the ToString() method
* Sorting lists of values

Create a value type by implementing the `ValueType<T>` class, for example:

```csharp
public class Euro : Value<double>
{
    public Euro(double value) : base(value)
    {
    }

    // Add the methods and operators you need here
}
```


How to use it:
```csharp
var a = new Euro(3.5f);
var b = new Euro(3.5f);

if(a == b) // This works out of the box
{
    Console.WriteLine("Eureka!");
}
```

## How to create an entity

This package contains a base-class for a entities. It supports:

* Comparing entities by using .Equals(x), == and !=
* Ids

Create an entity by implementing the `Entity<T>` base-class. It provides a public propery called ID on every entity. It requires the class to be constructed with an Id. Obviously, you'll need more than just an Id. Add the properties you need to the constructor of the entity. Don't pass it to the base class. Example:

```csharp
public class Order : Entity<Order>
{
    public Euro Price { get; }

    // Important!!: Give it a public constructor
    public Order(Id<Order> id, Euro price) : base(id)
    {
        Price = price;
    }
}
```

Use it like this:

```csharp
var id = Id<Order>.CreateNew();
var price = new Euro(3.5f);

var order = new Order(id, price);
Console.WriteLine(order.Id);
Console.WriteLine(order.Price);
```

## How to create an aggregate

This package contains a base-class for a entities. It supports:

* Comparing entities by using .Equals(x), == and !=
* Ids

An aggregate is an entity. Create an entity by implementing the `Aggregate<T>` base-class. It provides a public propery called ID on every entity. It requires the class to be constructed with an Id. Obviously, you'll need more than just an Id. Add the properties you need to the constructor of the aggregate. Example:

```csharp
public class OrderAggregateRoot : Aggregate<OrderAggregateRoot>
{
    public Euro Price { get; }
    public Id<Order> OrderId { get; }

    public OrderAggregateRoot(Id<OrderAggregateRoot> id, Id<Order> orderId, Euro price) : base(id)
    {
        OrderId = orderId;
        OrderId = orderId;
    }
}
```

Use it like this:

```csharp
var id = Id<OrderAggregateRoot>.CreateNew();
var orderId = new Id<Order>(new Guid("6001300f-8c49-402a-9545-027c8917557d"));
var price = new Euro(3.5f);

var order = new OrderAggregateRoot(id, orderId, price);
Console.WriteLine(order.Id);
Console.WriteLine(order.OrderId);
Console.WriteLine(order.Price);
```
