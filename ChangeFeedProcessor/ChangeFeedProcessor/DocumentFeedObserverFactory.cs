using Microsoft.Azure.Documents.ChangeFeedProcessor;
using Microsoft.Azure.Documents.Client;

namespace ChangeFeedProcessor.ChangeFeedProcessor
{
    public class DocumentFeedObserverFactory : IChangeFeedObserverFactory
    {
        private DocumentClient client;
        private DocumentCollectionInfo collectionInfo;

        public DocumentFeedObserverFactory(DocumentClient destClient, DocumentCollectionInfo destCollInfo)
        {
            this.collectionInfo = destCollInfo;
            this.client = destClient;
        }
        public IChangeFeedObserver CreateObserver()
        {
            DocumentFeedObserver newObserver = new DocumentFeedObserver(client, collectionInfo);
            return newObserver;
        }
    }
}
