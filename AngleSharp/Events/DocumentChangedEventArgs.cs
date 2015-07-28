using System;
using AngleSharp.Dom;

namespace AngleSharp.Events
{
    public class DocumentChangedEventArgs : EventArgs
    {
        #region Properties

        public IDocument NewDocument { get; }

        #endregion

        #region Methods

        public DocumentChangedEventArgs(IDocument newDocument)
        {
            NewDocument = newDocument;
        }

        #endregion
    }
}
