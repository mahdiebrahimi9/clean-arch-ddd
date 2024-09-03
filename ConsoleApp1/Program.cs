
using Book_Domain.Shared;
using Book_Domain.Users;
using Book_Domain.Users.ValueObjects;

//var money1 = Money.FromToman(100);
//var money2 = Money.FromToman(100);
//Console.WriteLine(money1 == money2);

//var user = new User("Mike", "Mikes", new PhoneNumber("09058893215"));
//var user2 = new User("Mike", "Mikes", new PhoneNumber("09058893215"));
var user = new User("mike","mikes",new PhoneBook(new PhoneNumber("09038894025"),new PhoneNumber("09038894025")));
var user2 = new User("mike","mikes",new PhoneBook(new PhoneNumber("09038894025"),new PhoneNumber("09038894025")));

Console.WriteLine(user.PhoneNumber == user2.PhoneNumber);