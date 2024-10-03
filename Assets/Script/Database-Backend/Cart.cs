using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart
{
    private int cartID;
    Dictionary<Book, int> booksInCart=new Dictionary<Book, int>();

    public Cart(int cartID)
    {
        this.cartID = cartID;
    }

    public bool AddBookToCart(Book book,int amount)
    {
        if (booksInCart.ContainsKey(book)) {
            this.booksInCart[book]+=amount;
        }
        else
        {
            this.booksInCart.Add(book, amount);
        }
        return true;
    }
    public void ReduceBookFromCart(Book book) { 
    }
    public void RemoveBookFromCart(Book book) { 
        this.booksInCart[book]--;
    }
    public void Clear() { 
        this.booksInCart = null;
    }
}
