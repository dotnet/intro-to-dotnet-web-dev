Random random = new Random();
int daysUntilExpiration = random.Next(12);
int discountPercentage = 0;

Console.WriteLine(daysUntilExpiration);

if (daysUntilExpiration <= 10 && daysUntilExpiration > 5)
{
    discountPercentage = 0;
    Console.Write("Your subscription will expire soon. Renew now!");
}
else if (daysUntilExpiration <= 5 && daysUntilExpiration > 1)
{
    discountPercentage = 10;
    Console.WriteLine("Your subscription expires in " + daysUntilExpiration + " days.");
    Console.Write("Renew now and save " + discountPercentage + "%!");
}
else if (daysUntilExpiration == 1)
{
    discountPercentage = 20;
    Console.WriteLine("Your subscription expires in a day!");
    Console.Write("Renew now and save " + discountPercentage + "%!");
}
else if (daysUntilExpiration < 1)
{
    discountPercentage = 0;
    Console.WriteLine("Your subscription has expired.");
}