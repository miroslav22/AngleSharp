namespace AngleSharp.Dom.Html
{
    using AngleSharp.Attributes;
    using AngleSharp.Dom.Events;

    /// <summary>
    /// Represents the body HTML element.
    /// </summary>
    [DomName("HTMLBodyElement")]
    public interface IHtmlBodyElement : IHtmlElement, IWindowEventHandlers
    {
        /// <summary>
        /// Manually runs the on load event handler
        /// </summary>
        void ManuallyRunOnLoad();
    }
}
