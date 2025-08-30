using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Hafta_25_08._2025
{
    class BankAccount
    {
        private int balance;
        private string AccountNo;

        public BankAccount(int StartingBalance, string accountNo)
        {
            balance = StartingBalance;
            AccountNo = accountNo;
        }

        public void ViewBalance()
        {
            Console.WriteLine("Hesap No: " + AccountNo);
            Console.WriteLine("Mevcut Bakiyeniz: "+ balance + "TL");
        }
        
        public void DepositBalance(int Amount)
        {
            if (Amount > 0)
            {
                balance += Amount;
                Console.WriteLine(Amount + "Tl Yatırılmıştır. Mevcut Bakiyeniz: "+ balance + "TL");
            }
            else
            {
                Console.WriteLine("Lütfen Geçerli Bir Miktar giriniz.");
            }
        }
        public void WithdrawBalance(int Amount)
        {
            if (Amount <= 0)
            {
                Console.WriteLine("Lütfen Geçerli Bir Miktar giriniz.");
            }
            else if (Amount > balance)
            {
                Console.WriteLine("Yetersiz Bakiye");
            }
            else
            {
                balance -= Amount;
                Console.WriteLine(Amount + "Tl Çekilmiştir. Mevcut Bakiyeniz: " + balance + "TL");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Lutfen hesap No giriniz: ");
            string inputAccountNo = Console.ReadLine();
            long accountNo;

            while (!long.TryParse(inputAccountNo, out accountNo))
            {
                Console.Write("⚠ Hatalı giriş! Hesap numarası sadece rakamlardan oluşmalıdır : ");
                inputAccountNo = Console.ReadLine();
            }


            BankAccount Account = new BankAccount(1000, accountNo.ToString());
            bool continueLoop = true;

            while (continueLoop)
            {
                Console.WriteLine("\n--- OOP Banka Uygulaması ---");
                Console.WriteLine("1-Bakiye Görüntüle\n2-Para Yatır\n3-Para Çekme\n4-Çıkış");
                string entrance = Console.ReadLine();
                int Select;

                if (!int.TryParse(entrance, out Select))
                {
                    Console.WriteLine("⚠ Lütfen geçerli bir sayı giriniz!");
                    continue;
                }

                switch (Select)
                {
                    case 1:
                        Account.ViewBalance();
                        break;
                    case 2:
                        Console.Write("Yatıralacak Miktarı Giriniz: ");
                        if(int.TryParse(Console.ReadLine(), out int Deposit))
                        {
                            Account.DepositBalance(Deposit);
                        }
                        else
                            Console.WriteLine("Geçerli Bir sayı giriniz!");
                        break;
                    case 3:
                        Console.Write("Lütfen Çekmek istediğiniz Miktarı Giriniz: ");
                        if (int.TryParse(Console.ReadLine(),out int Withdraw))
                        {
                            Account.WithdrawBalance(Withdraw);
                        }
                        else
                            Console.WriteLine("Geçerli Bir sayı giriniz!");
                        break;
                    case 4:
                        continueLoop = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz İşlem");
                        break;
                }
            }
        }
    }
}
