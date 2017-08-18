using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.Infrastructure.Database.Tables;
using SQLite;
using Xamarin.Forms;

namespace Meaning.Infrastructure.Database
{
    public class MeanDatabase
    {
        public static object Locker = new object();
        public SQLiteConnection Database;

        private static MeanDatabase instance;
        private MeanDatabase()
        {
            CreateDatabase();

            // insert just once the defaults:
            var quote = Database.Table<PurposeItem>().ToList();
            if (quote.Count != 0) return;

            InsertAppMotivation();
            InsertItemsMotivation();
            InsertDefaultForgets();
            InsertDefaultPurposes();
            InsertDefaultQuestions();
            InsertDefaultQuotes();
            InsertDefaultSuggestions();
        }

        private void CreateDatabase()
        {
            lock (Locker)
            {
                Database = DependencyService.Get<ISqLite>().GetConnection();

                // creating tables:
                Database.CreateTable<PurposeItem>();
                Database.CreateTable<Purpose>();
                Database.CreateTable<ItemMotivation>();
            }
        }

        public static MeanDatabase GetInstance()
        {
            lock (Locker)
            {
                return instance ?? (instance = new MeanDatabase());
            }
        }

        #region insert default changeable information
        private void InsertDefaultPurposes()
        {
            var purposeOne = new Purpose()
            {
                Content = "This is a model of dream. Click for details and edit.",
                Notes = "This would be any kind of adnotation associated with the purpose.",
                DueDate = DateTime.Now.AddDays(10),
                ProgressLevel = 1
            };

            var purposeTwo = new Purpose()
            {
                Content = "This is a second model of purpose as example.",
                Notes = "It is not neccessary to have notes for every purpose that you add.",
                DueDate = DateTime.Now.AddDays(25),
                ProgressLevel = 2
            };

            lock (Locker)
            {
                Database.Insert(purposeOne);
                Database.Insert(purposeTwo);
            }
        }

        private void InsertDefaultQuestions()
        {
            var questionOne = new PurposeItem()
            {
                Content = "What would you do differently if you knew no one judges you?",
                Notes = "People that want to judge will judge you anyway.",
                Status = ItemStatus.ToRemember,
                Type = ItemType.Question
            };

            var questionTwo = new PurposeItem()
            {
                Content = "What is the difference between being alive and truly living?",
                Notes = "define life",
                Status = ItemStatus.Cool,
                Type = ItemType.Question
            };

            var questionThree= new PurposeItem()
            {
                Content = "If you win one million dollar, would you quit your job? How would your life be?",
                Notes = "do you think money stop you from archiving your dreams?",
                Status = ItemStatus.Wow,
                Type = ItemType.Question
            };

            var questionFour = new PurposeItem()
            {
                Content = "What single advice would you give to a new baby born? ",
                Notes = "it is so important to always remember…",
                Status = ItemStatus.Interesting,
                Type = ItemType.Question
            };

            var questionFive = new PurposeItem()
            {
                Content = "How important is the word “must” in your life? ",
                Notes = "you must do the things this way, you must be nice, you must….",
                Status = ItemStatus.Touching,
                Type = ItemType.Question
            };

            lock (Locker)
            {
                Database.Insert(questionOne);
                Database.Insert(questionTwo);
                Database.Insert(questionThree);
                Database.Insert(questionFour);
                Database.Insert(questionFive);
            }
        }

        private void InsertDefaultQuotes()
        {
            var quoteOne = new PurposeItem()
            {
                Content = "All our dreams can come true if we have the courage to pursue them.",
                Notes = "have perseverance",
                Status = ItemStatus.Cool,
                Type = ItemType.Quote
            };

            var quoteTwo = new PurposeItem()
            {
                Content = "Every great dream begins with a dreamer. Always remember: you have within yourself the strength, the patience and the passion to reach for the stars to change the world.",
                Notes = "just have faith",
                Status = ItemStatus.ToRemember,
                Type = ItemType.Quote
            };

            lock (Locker)
            {
                Database.Insert(quoteOne);
                Database.Insert(quoteTwo);
            }
        }

        private void InsertDefaultSuggestions()
        {
            var suggestionOne = new PurposeItem()
            {
                Content = "https://www.youtube.com/watch?v=KBChcaDqKyg",
                Notes = "everybody dies, but not everybody lives – I really like this short video.",
                Status = ItemStatus.Touching,
                Type = ItemType.Suggestion
            };

            var suggestionTwo = new PurposeItem()
            {
                Content = "The alchemist, by Paulo Coehlo ",
                Notes = "a book about choosing the path in life, about faith and growing",
                Status = ItemStatus.Interesting,
                Type = ItemType.Suggestion
            };

            var suggestionThree = new PurposeItem()
            {
                Content = "Thinking fast and slow, by Daniel Kahneman",
                Notes = "a book about the way our minds work, about why we think and do certain things; getting to better know yourself is a must in the process of evolution.",
                Status = ItemStatus.Interesting,
                Type = ItemType.Suggestion
            };

            lock (Locker)
            {
                Database.Insert(suggestionOne);
                Database.Insert(suggestionTwo);
                Database.Insert(suggestionThree);
            }
        }

        private void InsertDefaultForgets()
        {
            var forgetOne = new PurposeItem()
            {
                Content = "Stop wasting time on watching TV and scrolling on social networks.",
                Notes = "if you spend more than 4 hours a day on these, this is like a part time job.",
                Status = ItemStatus.Interesting,
                Type = ItemType.Forget
            };

            var forgetTwo = new PurposeItem()
            {
                Content = "Stop comparing yourself with others.",
                Notes = "do not design your life based on others; make your own wishes and you will have the energy to touch the sky.",
                Status = ItemStatus.Wow,
                Type = ItemType.Forget
            };

            var forgetThree = new PurposeItem()
            {
                Content = "Stop thinking about what others think about you.",
                Notes = "you do not have to explain yourself, just live the way you want.",
                Status = ItemStatus.Cool,
                Type = ItemType.Forget
            };

            lock (Locker)
            {
                Database.Insert(forgetOne);
                Database.Insert(forgetTwo);
                Database.Insert(forgetThree);
            }
        }
        #endregion

        #region insert static information
        private void InsertAppMotivation()
        {
            var appMotivation = new ItemMotivation()
            {
                Content = "This application was born because I believe in dreams, but, most of all, I believe in our need of not forgetting to dream. \r\n Sometimes everyday life, especially in this society, keeps us so busy or worry that we forget who we really are. Or, sadly, makes us believe that we can never fulfill our dreams. \r\n \r\n I am a dreamer, a have faith, I love believing. \r\n \r\n And I believe that, if I don't lose my faith, I will find a way to accomplish my dreams \r\n \r\n So, no matter what, do not forget to wish, to desire, to dream. \r\n And write down your dreams! I offer you this app for your phone or tablet, but it doesn't really matter where you write them as long as you do it. \r\n You can store them in your phone, but you can also write them down on a piece of paper and put them in a place so you see them very often. \r\n Just don't forget about them! \r\n \r\n This app wants to be of great help for those of you that find motivation in stories, quotes, questions that inspire you. \r\n \r\n Most of all, I believe in questions, questions that make me understand why I want something, because this gives power to my dreams. \r\n But there are also good movies or books that can get to me in the right moment so I feel inspired. \r\n It doesn't matter which way I choose, I need to have all these for all the moments I dream, but, mostly, for the one when I feel I'm lost. \r\n \r\n And I found something new: my <forget abouts> list: it is precious because this way I learn every day not to waste my time and my energy - they are limited. \r\n \r\n So I have built this app for my needs and I decided to share it to the world. If there is someone than will find it useful, I will be twice happy. \r\n \r\n Also, if that someone will ever want to write me, please fill free: aninamaev@outlook.com. \r\n \r\n Enjoy and remember to design the reality around you from your dreams! Don't let others create your life and don't go on just like that, based on inaction. Life is as beautiful as you make it! And you have to have faith!",
                Type = ItemType.App
            };
            lock (Locker)
            {
                Database.Insert(appMotivation);
            }
        }

        private void InsertItemsMotivation()
        {
            #region purpose motivation
            var purposeMotivation = new ItemMotivation()
            {
                Content = "Believe your dreams can build your life!",
                Type = ItemType.Purpose
            };
            lock (Locker)
            {
                Database.Insert(purposeMotivation);
            }
            #endregion

            #region suggestion motivation
            var suggestionMotivation = new ItemMotivation()
            {
                Content = "There are movies and books that can be a real help in our growth. Some of them come to us in the right moment and the right place. \r\n \r\n Sometimes we hear about something maybe 3 times in a short interval of time. They deserve our attention. But you may have time for them or you must make time for them. \r\n \r\n Keep them somewhere so you can view and review those wonderful things that will make you have faith, wonder about life and help you grow up so you become the person you would like to meet.",
                Type = ItemType.Suggestion
            };
            lock (Locker)
            {
                Database.Insert(suggestionMotivation);
            }
            #endregion

            #region quote motivation
            var quoteMotivation = new ItemMotivation()
            {
                Content = "Sometimes we encounter things that other people used to believe and make our heart melt or simply make our mind believe. \r\n \r\n Having a collection of these quotes and viewing them once in a while will be your amulet – they will make you remember who and what you are.",
                Type = ItemType.Quote
            };
            lock (Locker)
            {
                Database.Insert(quoteMotivation);
            }
            #endregion

            #region question motivation
            var questionMotivation = new ItemMotivation()
            {
                Content = "Asking yourself questions can be important. And even more important is not lying to yourself. \r\n \r\n After a while, if the dialog is authentic, it will be your dialog with the society and the world. \r\n \r\n Let the dialog be sincere, so you build your life on solid pillar. Make your desires become your reality. For that you need to be honest with yourself and never stop knowing yourself. \r\n \r\n You will not always have the answers immediately, so make a list of questions that make you wonder, keep them, renew them and grow up with them!",
                Type = ItemType.Question
            };
            lock (Locker)
            {
                Database.Insert(questionMotivation);
            }
            #endregion

            #region forget motivation
            var forgetMotivation = new ItemMotivation()
            {
                Content = "Perseverance is one of the keys in life. Sometimes it is more confortable to just waste time. But wasting time is wasting life and you will wake up on day saying: „I wish I started earlier.” \r\n \r\n There is “no earlier”, but also “no late”. It is just about getting out of your comfort zone and making new habits. \r\n \r\n Writing down a list of habits that you want to give up is, sometimes, a must. Suddenly you will have more time and energy for designing your life. \r\n \r\n Make your own list and take a look at it every day!",
                Type = ItemType.Forget
            };
            lock (Locker)
            {
                Database.Insert(forgetMotivation);
            }
            #endregion
        }
        #endregion
    }
}