using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.ChangeFeedProcessor;
using Microsoft.Azure.Documents.Client;
using Document = Microsoft.Azure.Documents.Document;

namespace ChangeFeedProcessor.ChangeFeedProcessor
{
    public class DocumentFeedObserver : IChangeFeedObserver
    {
        private readonly DocumentClient client;
        private readonly Uri destinationCollectionUri;

        public DocumentFeedObserver(DocumentClient client, DocumentCollectionInfo destCollInfo)
        {
            this.client = client;

            if (destCollInfo == null) return;

            destinationCollectionUri = UriFactory.CreateDocumentCollectionUri("ToDoList", "Items");
        }

        public Task OpenAsync(ChangeFeedObserverContext context)
        {
            return Task.CompletedTask;
        }

        public Task CloseAsync(ChangeFeedObserverContext context, ChangeFeedObserverCloseReason reason)
        {
            return Task.CompletedTask;
        }


        public Task ProcessChangesAsync(ChangeFeedObserverContext context, IReadOnlyList<Document> docs)
        {
            foreach (var doc in docs)
            {
                if (destinationCollectionUri != null)
                {
                    client.UpsertDocumentAsync(destinationCollectionUri, doc);
                }
            }
            return Task.CompletedTask;
        }
    }
}
