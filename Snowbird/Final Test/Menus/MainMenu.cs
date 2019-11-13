using System;
using System.Collections.Generic;

namespace Final_Test.Menus {
    public static class MainMenu {

        public static void Run() {

            Console.Clear();
            Console.WriteLine("Welcome {0}! \n\nYour wallets:", Snowbird.user.Username);

            List<string>[] wallets = Snowbird.user.Wallets;

            for (int i = 0; i < Snowbird.user.WalletCount; i++) {
                if (wallets[2][i] == "0") {
                    Console.WriteLine(" - Physical wallet\t{0} {1}\t\t{2}", wallets[3][i], wallets[4][i], wallets[7][i]);
                } else {
                    Console.WriteLine(" - Bank account ({0})", wallets[5][i]);
                }

            }

        }

    }
}
