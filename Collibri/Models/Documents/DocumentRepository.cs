using Collibri.Models.DataHandling;

namespace Collibri.Models.Documents
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IDataHandler _dataHandler;


        public DocumentRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public Document? CreateDocument(Document document, int sectionId)
        {
            var documentList = _dataHandler.GetAllItems<Document>(ModelType.Documents);
            document.Id = new Random().Next(1, int.MaxValue);

            foreach (var doc in documentList)
            {
                if (doc.SectionId.Equals(sectionId) && doc.Id == document.Id)
                {
                    return null;
                }
            }

            document.SectionId = sectionId;
            documentList.Add(document);

            _dataHandler.PostAllItems(documentList, ModelType.Documents);

            return document;
        }

        public IEnumerable<Document> GetDocuments(int sectionId)
        {
            var documentList = _dataHandler.GetAllItems<Document>(ModelType.Documents);
            return documentList.Where(document => document.SectionId == sectionId);
        }

        public Document? DeleteById(int id)
        {
            var documentList = _dataHandler.GetAllItems<Document>(ModelType.Documents);
            var documentToDelete = documentList.SingleOrDefault(x => x.Id == id);
            
            if (documentToDelete == null || !documentList.Remove(documentToDelete))
            {
                return null;
            }
            
            _dataHandler.PostAllItems(documentList, ModelType.Documents);
            return documentToDelete;
        }
        

        public Document? UpdateDocument(Document document, int id)
        {
            var documentList = _dataHandler.GetAllItems<Document>(ModelType.Documents);
            var documentToUpdate = documentList.SingleOrDefault(x => x.Id == id);
            
            if (documentToUpdate == null)
            {
                return null;
            }
            
            documentToUpdate.Title = document.Title;
            documentToUpdate.Text = document.Text;
            _dataHandler.PostAllItems(documentList, ModelType.Documents);

            return documentToUpdate;
        }
    }
}