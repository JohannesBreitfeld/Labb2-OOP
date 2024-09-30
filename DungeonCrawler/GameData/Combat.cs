using System.Drawing;

internal class Combat
{

    public void PlayerAttack(Player player, Enemy enemy, int row = 1)
    {
        int attackThrow = player.AttackDice.Throw();
        int defenseThrow = enemy.DefenceDice.Throw();
        int attackDamage = attackThrow - defenseThrow;
        if (attackDamage > 0)
        {
            enemy.Health -= attackDamage;
        }
        Console.SetCursorPosition(0, row);
        Console.ForegroundColor = player.Color;

        if (enemy.Health <= 0)
        {
            Console.WriteLine($"You (ATK: {player.AttackDice} => {attackThrow}) attacked the {enemy.Name} " +
                $"(DEF: {enemy.DefenceDice} => {defenseThrow}), killing it instantly.");
        }
        else
        {
            switch (attackDamage)
            {
                case <= 0:
                    {
                        Console.WriteLine($"You (ATK: {player.AttackDice} => {attackThrow}) attacked the {enemy.Name} " +
                            $"(DEF: {enemy.DefenceDice} => {defenseThrow}), without wounding it.");
                        break;
                    }
                case 1:
                case 2:
                case 3:
                    {
                        Console.WriteLine($"You (ATK: {player.AttackDice} => {attackThrow}) attacked the {enemy.Name} " +
                            $"(DEF: {enemy.DefenceDice} => {defenseThrow}), slightly wounding it.");
                        break;
                    }
                case 4:
                case 5:
                case 6:
                    {
                        Console.WriteLine($"You (ATK: {player.AttackDice} => {attackThrow}) attacked the {enemy.Name} " +
                            $"(DEF: {enemy.DefenceDice} => {defenseThrow}), moderatly wounding it.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"You (ATK: {player.AttackDice} => {attackThrow}) attacked the {enemy.Name} " +
                            $"(DEF: {enemy.DefenceDice} => {defenseThrow}), severly wounding it.");
                        break;
                    }
            }
            Thread.Sleep(500);
        }

    }

    public void EnemyAttack(Player player, Enemy enemy, int row = 2)
    {
        int attackThrow = enemy.AttackDice.Throw();
        int defenseThrow = player.DefenceDice.Throw();
        int attackDamage = attackThrow - defenseThrow;
        if (attackDamage > 0)
        {
            player.Health -= attackDamage;
        }
        Console.SetCursorPosition(0, row);
        Console.ForegroundColor = ConsoleColor.Red;

        if (player.Health <= 0)
        {
            Console.WriteLine($"The {enemy.Name} (ATK: {enemy.AttackDice} => {attackThrow}) attacked you " +
                        $"(DEF: {player.DefenceDice} => {defenseThrow}), killing you instantly(GAME OVER).");
        }
        else
        {
            switch (attackDamage)
            {
                case <= 0:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"The {enemy.Name} (ATK: {enemy.AttackDice} => {attackThrow}) attacked you " +
                            $"(DEF: {player.DefenceDice} => {defenseThrow}), but did not manage to do any damage.");
                        break;
                    }
                case 1:
                case 2:
                case 3:
                    {
                        Console.WriteLine($"The {enemy.Name} (ATK: {enemy.AttackDice} => {attackThrow}) attacked you " +
                            $"(DEF: {player.DefenceDice} => {defenseThrow}), sligthly wounding you.");
                        break;
                    }
                case 4:
                case 5:
                case 6:
                    {
                        Console.WriteLine($"The {enemy.Name} (ATK: {enemy.AttackDice} => {attackThrow}) attacked you " +
                            $"(DEF: {player.DefenceDice} => {defenseThrow}), moderately wounding you.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"The {enemy.Name} (ATK: {enemy.AttackDice} => {attackThrow}) attacked you " +
                            $"(DEF: {player.DefenceDice} => {defenseThrow}), severly wounding you.");
                        break;
                    }
            }
        }

    }






}

