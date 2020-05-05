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

``` Install-Package DomainDrivenDesign.DomainObjects -Version 0.0.8 ```

## How to create a value-type

This package contains a base-class for a value type. It supports:

* Comparing value types by the values it contains using .Equals(x), == and !=
* Converting it to a string using the ToString() method
* Sorting lists of values

Create a value type by implementing the `ValueType<T>` class, for example:

```
    public class Euro : Value<double>
    {
        public Euro(double value) : base(value)
        {
        }

        // Add the methods and operators you need here
    }
```


How to use it:
```
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

Create an entity by implementing the `Entity<T>` base-class. It provides a public property called ID on every entity. Always construct an entity with an Id. Entities are more than just an Id. Add the properties you need to the constructor of the entity. Don't pass it to the base class. Example:

```
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

```
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

Create an aggregate by implementing the `Aggregate<T>` base-class. It provides a public property called ID on every aggregate. Always construct an entity with an Id. Aggregates are more than just an Id. Add the properties you need to the constructor of the aggregate. Don't pass it to the base class. Example:

```
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

```
    var id = Id<OrderAggregateRoot>.CreateNew();
    var orderId = new Id<Order>(new Guid("6001300f-8c49-402a-9545-027c8917557d"));
    var price = new Euro(3.5f);

    var order = new OrderAggregateRoot(id, orderId, price);
    Console.WriteLine(order.Id);
    Console.WriteLine(order.OrderId);
    Console.WriteLine(order.Price);
```

## See it in action!

Use this repository as a reference. See how to use the DomainDrivenDesign.DomainObjects NuGet package [in this solution](https://github.com/appie2go/steal-this-code), in this [project](https://github.com/appie2go/steal-this-code/tree/master/Source/Dispatching).