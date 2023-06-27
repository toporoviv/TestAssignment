using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestAssignment.BL.Abstraction
{
    public sealed class ElementMerger : IElementMerger
    {
        private static ElementMerger _elementMerger = new ElementMerger();

        private ElementMerger()
        {
        }

        public IEnumerable<IElement> MergeElements(IEnumerable<IElement> elements, IElement newElement)
        {
            elements = elements.Where(x => x.Number != newElement.Number).OrderBy(x => x.Number);

            bool contains = false;

            foreach (var element in elements)
            {
                if (element.Number > newElement.Number && !contains)
                {
                    contains = true;
                    yield return newElement;
                }

                yield return element;
            }
        }

        public static IElementMerger Get()
        {
            return _elementMerger;
        }
    }
}
