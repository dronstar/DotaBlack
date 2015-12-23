Добавил в основной код программы(Form1.cs), функцию для проверки введеного имени, если имя не введено дальше ничего не произойдет.
 {
                int num;
                if (game._Name == null)
                    MessageBox.Show("ENTER NAME", "BlackJack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    if (game._Bet == 0)
                    MessageBox.Show("NEED BET", "BlackJack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                        if (flag == true)
                {
