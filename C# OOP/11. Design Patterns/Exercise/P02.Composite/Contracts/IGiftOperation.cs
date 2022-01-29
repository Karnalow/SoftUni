using P02.Composite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Composite.Contracts
{
    public interface IGiftOperation
    {
        void Add(GiftBase gift);
        void Remove(GiftBase gift);
    }
}
