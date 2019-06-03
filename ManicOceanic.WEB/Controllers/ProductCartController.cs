﻿using ManicOceanic.DATA.Data;
using ManicOceanic.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using ManicOceanic.DOMAIN.Entities.Sales;

namespace ManicOceanic.WEB.Controllers
{
  public class ProductCartController : Controller
  {
    private readonly MOContext _dbContext;
    private string strCart = "Cart";

    public ProductCartController(MOContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IActionResult Index()
    {
      if (string.IsNullOrEmpty(HttpContext.Session.GetString(strCart)))
      {
        return View();
      }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(strCart)))
            {
                return View();
            }
            var cartList = LoadSession();
            if (cartList.Count <=0 )
            {
                return View(); 
            }

    public IActionResult OrderNow(Guid? id)
    {
      if (id == null)
      {

        return BadRequest();
      }

      if (string.IsNullOrEmpty(HttpContext.Session.GetString(strCart)))
      {
        var newProduct = _dbContext.Products.Find(id);

        if (newProduct.Stock > 0)
        {
          List<Cart> IsCart = new List<Cart>
                    {
                        new Cart(_dbContext.Products.Find(id),1)
                    };
          HttpContext.Session.SetString(strCart, JsonConvert.SerializeObject(IsCart));
        }
      }
      else
      {
        var cartList = LoadSession();

        var chosenProduct = cartList.FirstOrDefault(x => x.Product.Id == id);


        if (chosenProduct != null)
        {
          cartList.FirstOrDefault(x => x.Product.Id == id).Quantity++;

          SaveToSession(cartList);

          return Redirect("/ProductCart/index");
        }
        else
        {
          var product = _dbContext.Products.Find(id);

          var stock = product.Stock;
          if (stock > 0)
          {
            cartList.Add(new Cart(product, 1));

            SaveToSession(cartList);
          }
        }
      }

      return Redirect("/ProductCart/index");
    }

    public IActionResult DeleteItem(Guid? id)
    {

      var cartList = LoadSession();

      if (id == null)
      {
        return View("Index", cartList);
      }

            if (chosenProduct != null)
            {
                if (cartList.Count == 1)
                {
                    cartList.Remove(chosenProduct);
                    SaveToSession(cartList);
                    return View("Index");
                }
                cartList.Remove(chosenProduct);

      if (chosenProduct != null)
      {
        cartList.Remove(chosenProduct);

        SaveToSession(cartList);

            return View("Index",cartList);
        }
        
        [HttpPost]
        public IActionResult ChangeQuantity([FromBody]Data data)           //
        {
            var quantity = data.Quantity;
            var productId = data.Id;

    public IActionResult ChoseShipping(string shippingName)
    {
      var shippingChoice = new Shipping();

      return View("Index");
    }

    [HttpPost]
    public IActionResult ChangeQuantity([FromBody]Data data)
    {
      var quantity = data.Quantity;
      var productId = data.Id;

      var cartList = LoadSession();

      var product = cartList.FirstOrDefault(x => x.Product.Id == productId);

      if (product != null)
      {
        product.Quantity = quantity;
      }

      SaveToSession(cartList);

      return Redirect("/ProductCart/index");
    }

    public void SaveToSession(List<Cart> listOfCarts)
    {
      HttpContext.Session.SetString(strCart, JsonConvert.SerializeObject(listOfCarts));
    }

    public List<Cart> LoadSession()
    {
      var strList = HttpContext.Session.GetString(strCart);
      var cartList = JsonConvert.DeserializeObject<List<Cart>>(strList);
      return cartList;
    }
  }

  public class Data
  {
    public Guid Id { get; set; }
    public int Quantity { get; set; }
  }
}