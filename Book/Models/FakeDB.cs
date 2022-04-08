using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class FakeDB
    {
        private List<Book> BooksData { get; set; }

        public FakeDB()
        {

            BooksData = new List<Book>
            { 

                new Book { 
                    bId = 1,
                    bTitle = "四季奇談:蕭山客監獄的救贖",
                    bOriginal = "Rita Hayworth And Shawshank Redemption" ,
                    bAuthor="史蒂芬·金",
                    bYear = "1982" ,
                    bPubHouse = "遠流出版事業股份有限公司" ,
                    bISBN = "9789573254003" ,
                    bTrans = "施寄青、 趙永芬、齊若蘭" ,
                    bMoney = "299" ,
                    bLaun="繁體中文",
                    bIntroduce = "《蕭山克的救贖》大陸譯名《肖申克的救贖》，是史蒂芬．金小說《四季奇譚》中的一篇中篇小說，原名《麗塔海華絲與蕭山克監獄的救贖》－春天的希望。故事由一名拘留在蕭山克監獄（又譯鯊堡監獄）的愛爾蘭人囚犯描述他所認識的一名含冤入獄的囚犯「安迪．杜佛尼」如何在漫長的牢獄歲月裡，做出各種令人意想不到的奇行；以及在最後數十年來的日子中，如何躲過典獄長等人的監視、逃離蕭山克監獄獲得他應得的自由的經過。為電影《刺激1995》的原著。 作者史蒂芬．愛德溫．金（Stephen Edwin King，1947年9月21日－），是一位作品多產、屢獲獎項的美國暢銷書作家，編寫過劇本、專欄評論，曾擔任電影導演、製片人以及演員。史蒂芬．金以恐怖小說著稱，他的作品還包括科幻小說、奇幻小說、短篇小說、非小說、影視劇本及舞台劇劇本。大多數的作品都曾被改編到其它媒體，像是電影、電視影集和漫畫書上。他在2003年獲得美國國家圖書獎終身成就獎。" ,
                    bPic = "/content/Images/xiao.jpg"

                },
                new Book {
                    bId = 2,
                    bTitle = "鬼店",
                    bAuthor="史蒂芬·金",
                    bOriginal = "The Shining" ,
                    bYear = "1977" ,
                    bPubHouse = "皇冠出版事業股份有限公司" ,
                    bISBN = "9789573254003" ,
                    bTrans = "黃意然" ,
                    bMoney = "279" ,
                    bLaun="繁體中文",
                    bIntroduce = "就在那個房間裡，透過拉起來的浴簾，他彷彿看到一個模糊的女人形體躺在浴缸裡──正如兒子丹尼所說的。即使關上了門，他仍恍似聽見那個死去多時的女人正爬出浴缸，要來歡迎她的訪客。傑克知道兒子常會看見一些奇怪的景象，有時甚至能感覺到「未來」才會發生的事。但他自己呢？難道他也發瘋了，就像第一任的冬季管理員那樣？多年前，第一任冬季管理員同樣是帶著全家赴任，最後卻突然發狂，先是拿斧頭活活砍死兩名幼女，再用獵槍殺害妻子後自殺！即使聽說了這場駭人的悲劇，傑克仍決定來這家著名的高山渡假飯店「全景」擔任冬季管理員，並帶著妻子溫蒂與五歲的丹尼同行。整個嚴冬休館期間，通往外界的路會被惡雪冰封，而他們一家人也將與世隔絕半年。但他別無選擇。曾是備受歡迎的名校老師、文壇新星，卻因酗酒和痛毆學生而變得一無所有，「全景」是他翻身的最後希望，他將在這裡完成偉大的巨著，然後討回那些他所應得的一切！他需要「全景」，然而傑克並不知道，「全景」也正等待著他……" ,
                    bPic = "/content/Images/guidien.jpg"

                },
            };
        }

        public Book GetBook(int Id)
        {
            for (int i = 0; i < BooksData.Count; i++)
            {
                if (BooksData[0].bId == Id)
                { 
                    // blablabla
                }
            }

            foreach (Book book in BooksData)
            {
                if (book.bId == Id)
                {
                    return book;
                }
            }

            return null;
        }
    }

    public class Book
    {
        public int bId { get; set; }
        /// <summary>
        /// 書的編號
        /// </summary>
        public string bTitle { get; set; }
        public string bOriginal { get; set; }
        public string bAuthor { get; set; }
        public string bYear { get; set; }
        public string bPubHouse { get; set; }
        public string bISBN { get; set; }
        public string bTrans { get; set; }
        public string bMoney { get; set; }
        public string bLaun { get; set; }
        public string bIntroduce { get; set; }
        public string bPic { get; set; }

        // <summary>
        // 取得書的名字
        // </summary>
        // <returns>書的名字</returns>

    }
}
