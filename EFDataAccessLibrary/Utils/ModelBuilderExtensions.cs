
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;

namespace EFDataAccessLibrary.Models
{
    public static class ModelBuilderExtensions
    {


        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
     new Question
     {
         Id = 1,
         CategoryName = "شخصیتی",
         QuestionGuid = Guid.NewGuid(),
         CategoryID = ((int)Categories.Personal),
         QuestionStr = "وقتی صحبت از دوستی می شود کدام ویژگی برای تو بیشترین ارزش را دارد؟ و اینکه آیا به راحتی دوست می شوی؟"
     },
      new Question
      {
          Id = 2,
          CategoryName = "چالش",
          QuestionGuid = Guid.NewGuid(),
          CategoryID = ((int)Categories.Challenge),
          QuestionStr = "آیا تا به حال از کسی سو استفاده کرده ای؟"
      },
      new Question
      {
          Id = 3,
          CategoryName = "سرگرمی",
          QuestionGuid = Guid.NewGuid(),
          CategoryID = ((int)Categories.Entertainement),
          QuestionStr = " اگر یک حیوان بودی چه بودی؟"
      },
       new Question
       {
           Id = 4,
           CategoryName = "شخصیتی",
           QuestionGuid = Guid.NewGuid(),
           CategoryID = ((int)Categories.Personal),
           QuestionStr = "آیا خود را شخص قابل اعتمادی می دانید؟ آیا دوستان تان شما را قابل اعتماد می دانند؟"
       },
        new Question
        {
            Id = 5,
            CategoryName = "شخصیتی",
            QuestionGuid = Guid.NewGuid(),
            CategoryID = ((int)Categories.Personal),
            QuestionStr = "آیا خرافاتی هستی؟"
        },
        new Question
        {
            Id = 6,
            CategoryName = "شخصیتی",
            QuestionGuid = Guid.NewGuid(),
            CategoryID = ((int)Categories.Personal),
            QuestionStr = "آیا خودت را متعصب یا نژادپرست می دانید؟"
        },
         new Question
         {
             Id = 7,
             CategoryID = ((int)Categories.Challenge),
             QuestionGuid = Guid.NewGuid(),
             CategoryName = "چالش",
             QuestionStr = "بدترین رازت را بگو؟"
         }) ;


     modelBuilder.Entity<Dare>().HasData(
   new Dare
   {
       Id = 1,
       CategoryName = "فیزیکی",
       DareGuid = Guid.NewGuid(),
       CategoryID = ((int)Categories.Physical),
       
       DareStr = "به مدت پنج دقیقه پاهای شرکت کننده سمت چپ خود را ماساژ بده"
   },
    new Dare
    {
        Id = 2,
        CategoryName = "چالش",
        DareGuid = Guid.NewGuid(),
        CategoryID = ((int)Categories.Challenge),
       
        DareStr = "یک قاشق کره بخور"
    },
    new Dare
    {
        Id = 3,
        CategoryName = "سرگرمی",
        DareGuid = Guid.NewGuid(),
        CategoryID = ((int)Categories.Entertainement),
       
        DareStr = "اولین کلمه ای که به ذهنت می رسد را فریاد بزن"
    },
     new Dare
     {
         Id = 4,
         CategoryName = "چالش",
         DareGuid = Guid.NewGuid(),
         CategoryID = ((int)Categories.Challenge),
         
         DareStr = "یک قطعه یخ در شلوار خود قرار بده و صبر کن تا آب شود"
     },
      new Dare
      {
          Id = 5,
          CategoryName = "چالش",
          DareGuid = Guid.NewGuid(),
          CategoryID = ((int)Categories.Challenge),
        
          DareStr = "ده بار دور خودت بگرد، بعد از آن سعی کن در خط مستقیم راه بروی"
      },

        new Dare
        {
            Id = 7,
            DareGuid = Guid.NewGuid(),
            CategoryID = ((int)Categories.Challenge),
            CategoryName = "چالش",
            
            DareStr = "با آهنگ انتخابی گروه برقص"
        });

        }

    }
}

