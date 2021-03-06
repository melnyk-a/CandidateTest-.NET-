﻿using System;

namespace CandidateTest.Presentation.Wpf.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    internal abstract class DependsUponAttribute : Attribute
    {
        private readonly string propertyName;

        public DependsUponAttribute(string propertyName)
        {
            this.propertyName = propertyName;
        }

        public string PropertyName => propertyName;
    }
}