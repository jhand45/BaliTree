using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BaliTreeData;
using BaliTreeData.Models;
using BaliTreeServices;

namespace XUnitTestBaliTree
{
    //[testclass?]
    public class IStockChangesTesting
    {
        public IStockChanges StockChanges;

        [Fact]
        public void MyFirstTest()
        {
            Assert.True(true);
        }

        [Fact]
        public void NewType_NewOrder_DateSharing_Properly()
        {
            //arrange
            var type = new StockType();
            type.TypeName = "Large Bowl";
            type.InStock = 0;

            var item = new StockItem();
            item.Date = DateTime.Now;
            item.ItemName = "Resin Bowl";
            item.AmountRecieved = 10;
            item.CostPrice = 20;
            item.Type = type;

            var firstEvent = new StockEvent();
            firstEvent.StockItem = item;
            firstEvent.Date = item.Date;
            firstEvent.Change = item.AmountRecieved;

            //act
            type.InStock = StockChanges.Recieved(type.InStock, firstEvent.Change);

            //assert
            Assert.Equal(firstEvent.Date, item.Date);
        }

        //[Fact]
        //public void NewType_NewOrder_10inItem_10inType_TestingRecieved()
        //{
        //    //arrange
        //    var type = new StockType();
        //    type.TypeName = "Large Bowl";
        //    type.InStock = 0;
        //    type.RRP = 0;
        //    type.AverageCost = 0;


        //    var item = new StockItem();
        //    item.Date = DateTime.Now;
        //    item.ItemName = "Resin Bowl";
        //    item.AmountRecieved = 10;
        //    item.CostPrice = 20;
        //    item.Type = type;
        //    item.Event = new StockEvent();

        //    item.Event.Date = item.Date;
        //    item.Event.Change = item.AmountRecieved;
        //    item.Event.EventType = Event.Recieved;
        //    item.Event.StockItem = item;

        //    //act
        //    type.InStock = StockChanges.Recieved(type.InStock, item.Event.Change);

        //    //assert
        //    Assert.Equal(10, type.InStock);
        //}
    }
}
