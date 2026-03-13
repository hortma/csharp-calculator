ConsoleColor originalColor = Console.ForegroundColor;
ConsoleColor errorColor = ConsoleColor.Red;
ConsoleColor successColor = ConsoleColor.Green;

void ErrorMessage(string msg) {
    Console.ForegroundColor = errorColor;
    Console.WriteLine(msg);
    Console.ForegroundColor = originalColor;
}

void SuccessMessage(string msg)
{
    Console.ForegroundColor = successColor;
    Console.WriteLine(msg);
    Console.ForegroundColor = originalColor;
}

Console.Write("C# Calculator by ");

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.Write("Arthur Hortmann");

Console.ForegroundColor = originalColor;
Console.WriteLine("");

Console.WriteLine("Has the operators of: +, -, * or x, ^ and /");

while (true)
{
    Console.WriteLine("");
    Console.Write("Type the first number: ");

    string? firstInput = Console.ReadLine();

    if (string.IsNullOrEmpty(firstInput))
    {
        ErrorMessage("Invalid input!");
        continue;
    }

    if (firstInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    bool aSuccess = double.TryParse(firstInput, out double a);

    if (!aSuccess)
    {
        ErrorMessage("Could not convert first number into an double!");
        continue;
    }

    Console.Write("Type the second number: ");

    string? secInput = Console.ReadLine();

    if (string.IsNullOrEmpty(secInput))
    {
        ErrorMessage("Invalid input!");
        continue;
    }

    bool bSuccess = double.TryParse(secInput, out double b);

    if (!bSuccess)
    {
        ErrorMessage("Could not convert second number into an double!");
        continue;
    }

    Console.Write("Type the operator: ");
    string? op = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(op))
    {
        ErrorMessage("Operator is empty or null!");
        continue;
    }

    op = op.Trim().ToLower();
    double output = 0;

    switch (op)
    {
        case "+":
            output = a + b; break;
        case "-":
            output = a - b; break;
        case "*":
            output = a * b; break;
        case "x":
            output = a * b; break;
        case "/":
            if (b == 0)
            {
                ErrorMessage($"Cannot divide {a} by zero!");
                continue;
            }

            output = a / b; break;
        case "^":
            output = Math.Pow(a, b); break;
        default:
            ErrorMessage($"Invalid operator! {op}");
            continue;
    }

    SuccessMessage($"{a} {op} {b} = {output:F2}");
}

Console.ForegroundColor = originalColor;
Console.WriteLine("Exiting...");