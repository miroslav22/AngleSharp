﻿namespace AngleSharp.DOM.Collections
{
    using AngleSharp.DOM.Css;
    using System;
    using System.Collections.Generic;

    static class QueryExtensions
    {
        /// <summary>
        /// Returns the first element within the document (using depth-first pre-order traversal
        /// of the document's nodes) that matches the given selector.
        /// </summary>
        /// <param name="elements">The elements to take as source.</param>
        /// <param name="selectors">A selector object.</param>
        /// <returns>An element object.</returns>
        public static T QuerySelector<T>(this NodeList elements, ISelector selectors)
            where T : class, IElement
        {
            return elements.QuerySelector(selectors) as T;
        }

        /// <summary>
        /// Returns the first element within the document (using depth-first pre-order traversal
        /// of the document's nodes) that matches the specified group of selectors.
        /// </summary>
        /// <param name="elements">The elements to take as source.</param>
        /// <param name="selector">A selector object.</param>
        /// <returns>An element object.</returns>
        public static IElement QuerySelector(this NodeList elements, ISelector selector)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                var element = elements[i] as IElement;

                if (element != null)
                {
                    if (selector.Match(element))
                        return element;

                    if (!element.HasChilds)
                        continue;

                    element = QuerySelector(element.ChildNodes, selector);

                    if (element != null)
                        return element;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a list of the elements within the document (using depth-first pre-order traversal
        /// of the document's nodes) that match the specified group of selectors.
        /// </summary>
        /// <param name="elements">The elements to take as source.</param>
        /// <param name="selector">A selector object.</param>
        /// <param name="result">A reference to the list where to store the results.</param>
        public static void QuerySelectorAll(this NodeList elements, ISelector selector, List<IElement> result)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                var element = elements[i] as IElement;

                if (element != null)
                {
                    if (selector.Match(element))
                        result.Add(element);

                    if (element.HasChilds)
                        QuerySelectorAll(element.ChildNodes, selector, result);
                }
            }
        }

        /// <summary>
        /// Returns a set of elements which have all the given class names.
        /// </summary>
        /// <param name="elements">The elements to take as source.</param>
        /// <param name="classNames">An array with class names to consider.</param>
        /// <param name="result">A reference to the list where to store the results.</param>
        public static void GetElementsByClassName(this NodeList elements, String[] classNames, List<IElement> result)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                var element = elements[i] as IElement;

                if (element != null)
                {
                    if (element.ClassList.Contains(classNames))
                        result.Add(element);

                    if (element.ChildElementCount != 0)
                        GetElementsByClassName(element.ChildNodes, classNames, result);
                }
            }
        }

        /// <summary>
        /// Returns a NodeList of elements with the given tag name. The complete document is searched, including the root node.
        /// </summary>
        /// <param name="elements">The elements to take as source.</param>
        /// <param name="tagName">A string representing the name of the elements. The special string "*" represents all elements.</param>
        /// <param name="result">A reference to the list where to store the results.</param>
        public static void GetElementsByTagName(this NodeList elements, String tagName, List<IElement> result)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                var element = elements[i] as IElement;

                if (element != null)
                {
                    if (tagName == null || element.NodeName.Equals(tagName, StringComparison.OrdinalIgnoreCase))
                        result.Add(element);

                    if (element.ChildElementCount != 0)
                        GetElementsByTagName(element.ChildNodes, tagName, result);
                }
            }
        }

        /// <summary>
        /// Returns a list of elements with the given tag name belonging to the given namespace.
        /// The complete document is searched, including the root node.
        /// </summary>
        /// <param name="elements">The elements to take as source.</param>
        /// <param name="namespaceUri">The namespace URI of elements to look for.</param>
        /// <param name="localName">Either the local name of elements to look for or the special value "*", which matches all elements.</param>
        /// <param name="result">A reference to the list where to store the results.</param>
        public static void GetElementsByTagNameNS(this NodeList elements, String namespaceUri, String localName, List<IElement> result)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                var element = elements[i] as IElement;

                if (element != null)
                {
                    if (element.NamespaceUri == namespaceUri && (localName == null || element.LocalName.Equals(localName, StringComparison.OrdinalIgnoreCase)))
                        result.Add(element);

                    if (element.ChildElementCount != 0)
                        GetElementsByTagNameNS(element.ChildNodes, namespaceUri, localName, result);
                }
            }
        }
    }
}