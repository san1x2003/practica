using System;
using EfCoreTest1;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IO;
using EfCoreTest1;
using System.Linq;
using Paktika;
//using Paktika;


/*using (ApplicationContext db = new ApplicationContext())
{
    var Zakaz = db.Zakazs.ToArray();
    Console.WriteLine("Список объектов");
    foreach (Zakaz u in Zakaz)
    {

        Console.WriteLine(u.id_klient + " " + u.id_post + " " + u.id_sklada + " " + u.id_sotrydnik + " " + u.id_product + " " + u.id_zakaza + " " + u.number_contract + " " + u.date_of_execution+ " " + u.adress);
    }
*/
/*
using (ApplicationContext db = new ApplicationContext())
{
  Zakaz test = new Zakaz { id_klient = 1, id_post = 1, id_sklada = 1, id_sotrydnik = 1, id_product = 1, id_zakaza = 1, number_contract=1, date_of_execution = new DateTime(2002,3,2), adress= "biryzova,2" };
  db.Zakazs.Add(test);
  db.SaveChanges();
  var Zakazs = db.Zakazs.ToArray();
  Console.WriteLine("Список объектов");
  foreach (Zakaz u in Zakazs)
{
 Console.WriteLine(u.id_klient + " " + u.id_post + " " + u.id_sklada + " " + u.id_sotrydnik + " " + u.id_product + " " + u.id_zakaza + " " + u.number_contract + " " + u.date_of_execution+ " " + u.adress);
}
}
*/
/*using (ApplicationContext db = new ApplicationContext())
    {
   ZZakaz? updorder = (from sotrydnik in db.sotrydniks where Zakaz.id == 1 select Zakaz ).First();
   if (updorder != null)
   {
       updorder.id_product = 1;
       db.SaveChanges();
   }
   var Zakazs = db.Zakazs.ToArray();
   Console.WriteLine("Список объектов");
   foreach (Zakaz u in Zakazs)
   {
       Console.WriteLine(u.id_klient + " " + u.id_post + " " + u.id_sklada + " " + u.id_sotrydnik + " " + u.id_product + " " + u.id_zakaza + " " + u.number_contract + " " + u.date_of_execution+ " " + u.adress);
   }
}*/
/*
using (ApplicationContext db = new ApplicationContext())
{
    Zakaz? delorder = (from Zakaz in db.Zakazs where Zakaz.id_sotrydnik == 1 select Zakaz).First();
    if (delorder != null)
    {
        db.Zakazs.Remove(delorder);
        db.SaveChanges();
    }
    var Zakazs = db.Zakazs.ToArray();
    Console.WriteLine("Список объектов");
    foreach (Zakaz u in Zakazs)
    {
        Console.WriteLine(u.id_klient + " " + u.id_post + " " + u.id_sklada + " " + u.id_sotrydnik + " " + u.id_product + " " + u.id_zakaza + " " + u.number_contract + " " + u.date_of_execution+ " " + u.adress);
    }
}*/
using (ApplicationContext db = new ApplicationContext())
{
    //Возвращает первый элемент последовательности
    var firstWith5Chars = db.Zakaz.ToArray().FirstOrDefault(s => s.id_zakaza == 3); //выводит заказ с номером 3
    Console.WriteLine(firstWith5Chars);

}
using (ApplicationContext db = new ApplicationContext())
{
    //пропускает определенное количество элементов
    var firstWith5Chars = db.Zakaz.Skip(2); //пропускает первые 2 элемента в базе данных
    Console.WriteLine(firstWith5Chars);

}
//Простая проекция
using (ApplicationContext db = new ApplicationContext())
{
    /*  var users = from p in db.Users.ToArray()
                        select p.Fio; */
    var Zakazs = db.Zakaz.ToArray().Select(p => p.id_zakaza);
    foreach (var p in Zakazs)
    {
        Console.WriteLine(p);
    }


}
// LinqАнонимный объект

using (ApplicationContext db = new ApplicationContext())
{
    /*var users = from p in db.Users.ToArray()
                          select new
                          {
                              Fio = p.Fio + "(New obj)",
                              Age = p.Age * 2
                          }; */
    var Zakaz = db.Zakaz.ToArray().Select(p => new
    {
        id_zakaza = p.id_zakaza + "(New obj)",
        id_sklada = p.id_sklada * 2
    });
    foreach (var p in Zakaz)
    {
        Console.WriteLine(p.id_zakaza + " " + p.id_sklada);
    }

}
//Переменные в операторах Linq
using (ApplicationContext db = new ApplicationContext())
{
    var users = from p in db.Zakaz.ToArray()
                let age = p.id_sklada * 2
                select new
                {
                    id_zakaza = p.id_zakaza + "(New obj)",
                    id_sklada = p.id_sklada
                };

    foreach (var p in users)
    {
        Console.WriteLine(p.id_zakaza + " " + p.id_sklada);
    }

}
//Декартово произведение
using (ApplicationContext db = new ApplicationContext())
{
    var users = from u in db.Zakaz.ToArray()
                from c in db.sotrydnik.ToArray()
                select new
                {
                    id_sklada = u.id_sklada,
                    id_sotrydnik = c.id_sotrydnik
                };
    // var users = db.Users.ToArray(). (db.Countries.ToArray(), (u, c) => new { Fio = u.Fio, Country = c.Name });
    foreach (var p in users)
    {
        Console.WriteLine(p.id_sklada + " " + p.id_sotrydnik);
    }

}
//Фильтрация коллекции
using (ApplicationContext db = new ApplicationContext())
{
    /* var users = from p in db.Users.ToArray()
                       where p.Id <= 2
                       select p.Fio;*/
    var Zakaz = db.Zakaz.ToArray().Where(p => p.id_zakaza <= 2).Select(p => p.id_zakaza);
    foreach (var p in Zakaz)
    {
        Console.WriteLine(p);
    }


}
//Сортировка коллекции
using (ApplicationContext db = new ApplicationContext())
{

    /*  var users = from u in db.Users.ToArray()
                        orderby u.Fio
                        select u;  */


    var Zakaz = db.Zakaz.ToArray().OrderBy(u => u.id_zakaza);
    foreach (var p in Zakaz)
    {
        Console.WriteLine(p.id_zakaza);
    }

}
//Объединение таблиц
using (ApplicationContext db = new ApplicationContext())
{

    /*    var users = from u in db.Users.ToArray() join
                        c in db.Companies.ToArray() on u.CompanyID equals c.Id
                        select new { user = u.Fio, company = c.Name };

         */


    var Zakaz = db.Zakaz.ToArray().Join(db.sotrydnik.ToArray(), u => u.id_zakaza, c => c.id_sotrydnik, (u, c) => new { Zakaz = u.id_zakaza, sotrydnik = c.id_post });
    foreach (var p in Zakaz)
    {
        Console.WriteLine(p.Zakaz + " " + p.sotrydnik);
    }

}
//Загрузка связанных данных
using (ApplicationContext db = new ApplicationContext())
{


    var Zakazs = db.Zakaz.Include(u => u.id_zakaza).ToArray();



    foreach (var p in Zakazs)
    {
        Console.WriteLine(p.id_sklada + " " + p.id_zakaza);
    }


}


