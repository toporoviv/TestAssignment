# Имеется
Коллекция данных с типом описанным интерфейсом

```csharp
public interface IElement
{
	public int Number { get; set; }
	public string Body { get; }
}

public interface IElement
{
	public int Number { get; set; }
	public string Body { get; }
}

var collection = new List<IElement>()
{
	new Element(1, "Item 1"),
	new Element(3, "Item 3"),
	new Element(2, "Item 2"),
	new Element(4, "Item 4"),
	new Element(7, "Item 7"),
	new Element(9, "Item 9"),
	new Element(8, "Item 8"),
	new Element(15, "Item 15")
};
```
# Необходимо
Написать singletone класс (не через DI контейнер), реализующий интерфейс

```csharp
public interface IElementMerger
{
	IEnumerable<IElement> MergeElements(IEnumerable<IElement> elements, IElement newElement);
}
```

который будет выполнять добавление элемента и смещение последующих элементов до первого пропуска, а именно добавив в коллекцию значение `new Element(2, "New Item")`, мы должны получить результат

```csharp
var result = new List<IElement>()
{
	new Element(1, "Item 1"),
	new Element(2, "New Item"),
	new Element(3, "Item 2"),
	new Element(4, "Item 3"),
	new Element(5, "Item 4"),
	new Element(7, "Item 7"),
	new Element(8, "Item 8"),
	new Element(9, "Item 9"),
	new Element(15, "Item 15")
};
```

Результатом должен собираться проект и выполняться тест
