using Newtonsoft.Json;
using Project1;

var person = new Person
{
    Name = "John Doe",
    Age = 30
};

// Serialize the Person object to a JSON string
var json = JsonConvert.SerializeObject(person);
Console.WriteLine("Serialized JSON: " + json);

// Deserialize the JSON string back to a Person object
var deserializedPerson = JsonConvert.DeserializeObject<Person>(json);
Console.WriteLine("Deserialized Person: Name = " + deserializedPerson?.Name + ", Age = " + deserializedPerson?.Age);

ValidatePerson(person);
person = new Person { Name = "", Age = 150 };
ValidatePerson(person);

static void ValidatePerson(Person person)
{
    // Create an instance of the validator
    var validator = new PersonValidator();

// Validate the person object
    var validationResult = validator.Validate(person);

    if (validationResult.IsValid)
    {
        Console.WriteLine("Validation Passed for Person: Name = " + person.Name);
    }
    else
    {
        Console.WriteLine("Validation failed for Person: Name = " + person.Name);
        foreach (var error in validationResult.Errors)
        {
            Console.WriteLine($"- {error.PropertyName}: {error.ErrorMessage}");
        }
    }
}





