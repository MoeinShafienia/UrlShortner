using System;
using Xunit;
using RA;
using System.Text.RegularExpressions;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyGet()
        {
            new RestAssured()
              .Given()
                .Name("Empty Get")
                .Header("content-type", "application/json")
                .Header("accept-Encoding", "utf-8")
              .When()
                .Get("http://localhost:5000/redirect/")
                .Then()
                .TestStatus("Empty Get", r => r == 400)
                .Assert("Empty Get");
        }

        [Fact]
        public void WrongGet()
        {
            new RestAssured()
              .Given()
                .Name("BullshitGet")
                .Header("content-type", "application/json")
                .Header("accept-Encoding", "utf-8")
              .When()
                .Get("http://localhost:5000/redirect/aaaaaaaa")
                .Then()
                .TestStatus("BullshitGet", r => r == 404)
                .Assert("BullshitGet");
        }

        [Fact]
        public void AlphabetShortUrlTest()
        { 
            new RestAssured()
              .Given()
                .Name("Is not Alphabetical")
                .Header("content-type", "application/json")
              .When()
                .Get("http://localhost:5000/redirect/ZkPRH678")
                .Then()
                .TestStatus("Not Alphabetical", r => r == 400)
                .AssertAll();
        }

        [Fact]
        public void Just8CharsTest()
        {
            new RestAssured()
              .Given()
                .Name("Less than 8 chars")
                .Header("content-type", "application/json")
                .Header("Accept-Encoding", "urf-8")
              .When()
                .Get("http://localhost:5000/redirect/kjsa")
                .Then()
                .TestStatus("Less than 8 chars", r => r == 400)
                .AssertAll();

            new RestAssured()
              .Given()
                .Name("More than 8 chars")
                .Header("content-type", "application/json")
                .Header("Accept-Encoding", "uft-8")
              .When()
                .Get("http://localhost:5000/redirect/jkhaflfdkjlh")
                .Then()
                .TestStatus("More than 8 chars", r => r == 400)
                .AssertAll();
        }


        [Fact]
        public void EmptyPost()
        {
        
            new RestAssured()
            .Given()
                .Name("Empty Post")
                .Header("Content-Type", "application/json")
                .Body("")
            .When()
                .Post("http://localhost:5000/urls")
            .Then()
                .TestStatus("Empty Post", r => {
                    Console.Write("status code i get:" + r);
                    return r == 400;})
                .Assert("Empty Post");
        }

        [Fact]
        public void EmptyJSON()
        {
            var body = new {
                url = ""
            };
            new RestAssured()
            .Given()
                .Name("EmptyJSON")
                .Header("Content-Type", "application/json")
                .Body(body)
            .When()
                .Post("http://localhost:5000/urls")
            .Then()
                .TestStatus("EmptyJSON", r => r == 400)
                .Assert("EmptyJSON");
        }

        [Fact]
        public void NotMatchingJSON()
        {
            var body = new {
                something = ""
            };
            new RestAssured()
            .Given()
                .Name("Empty Post")
                .Header("Content-Type", "application/json")
                .Body(body)
            .When()
                .Post("http://localhost:5000/urls")
            .Then()
                .TestStatus("Empty Post", r => r == 400)
                .Assert("Empty Post");
        }

        [Fact]
        public void TestShortUrlLength()
        {
            var body = new 
            {
                url = "https://www.alibaba.ir"
            };    
            new RestAssured()
             .Given()
                .Name("Length Checker")
                .Header("Content-Type", "application/json")
                .Body(body)
            .When()
                .Post("http://localhost:5000/ulrs")
            .Then()
                .TestBody("Length Test", u => ((string)u.ShortUrl).Length == 8)
                .TestStatus("Status code Test", s => s == 200)
                .Assert("Lenght checker");                
        }

        [Fact]
        public void ShortUrlContainsOnlyAlphabetTest() 
        {
            var body = new 
            {
                url = "https://ce.kntu.ac.ir"
            };    
            new RestAssured()
             .Given()
                .Name("Alphabets Checker")
                .Header("Content-Type", "application/json")
                .Body(body)
            .When()
                .Post("http://localhost:5000/urls")
            .Then()
                .TestBody("Alphabet Test", u => Regex.IsMatch((string)u.shortUrl, @"^[a-zA-Z]+$"))
                .TestStatus("Status code Test", s => s == 200)
                .Assert("Alphabet Test");
        } 

        [Fact]
        public void TestSupportUniCode() 
        {
            var body = new 
            {
                url = "http://varzesh3.com/رونالدو"
            };    
            new RestAssured()
             .Given()
                .Name("Utf8 support Checker")
                .Header("Content-Type", "application/json")
                .Body(body)
            .When()
                .Post("http://localhost:5000/urls")
            .Then()
                .TestStatus("Utf8 support test", s => s == 200)
                .AssertAll();                
        }
       
        
    }
}
