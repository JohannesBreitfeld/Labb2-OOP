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

        string attackMessage;
        if (enemy.Health <= 0)
        {
            attackMessage =  "killing it instantly.";
        }
        else
        {
            switch (attackDamage)
            {
                case <= 0:
                    {
                        attackMessage = "without wounding it.";
                        break;
                    }
                case 1:case 2:case 3:
                    {
                        attackMessage = "slightly wounding it.";
                        break;
                    }
                case 4: case 5:case 6:
                    {
                        attackMessage = "moderately wounding it.";
                        break;
                    }
                default:
                    {
                        attackMessage = "severly wounding it.";
                        break;
                    }
            }
        }
        Console.WriteLine($"You (ATK: {player.AttackDice} => {attackThrow}) attacked the {enemy.Name} " +
        $"(DEF: {enemy.DefenceDice} => {defenseThrow}), {attackMessage}".PadRight(100));
        if (row == 1) Thread.Sleep(500);
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
        Console.ForegroundColor = (attackDamage > 0) ? ConsoleColor.Red : ConsoleColor.Green;

        string attackMessage;
        if (player.Health <= 0)
        {
            attackMessage = "killing you instantly(GAME OVER).";
        }
        else
        {
            switch (attackDamage)
            {
                case <= 0:
                    {
                        attackMessage = "but did not manage to do any damage.";
                        break;
                    }
                case 1: case 2: case 3:
                    {
                        attackMessage = "sligthly wounding you.";
                        break;
                    }
                case 4: case 5: case 6:
                    {
                        attackMessage = "moderately wounding you.";
                        break;
                    }
                default:
                    {
                        attackMessage = "severly wounding you.";
                        break;
                    }
            }
        }
        Console.WriteLine($"The {enemy.Name} (ATK: {enemy.AttackDice} => {attackThrow}) attacked you " +
                          $"(DEF: {player.DefenceDice} => {defenseThrow}), {attackMessage}".PadRight(100));
        if (row == 1) Thread.Sleep(500);
    }
}

