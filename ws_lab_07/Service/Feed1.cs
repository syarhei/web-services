using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace Service {
    public class Feed1 : IFeed1 {
        public SyndicationFeedFormatter GetStudentNotes(string studentId) {
            SyndicationFeed feed = new SyndicationFeed("Subjects & Notes", "Get list of notes by all subjects for this student", null);
            List<SyndicationItem> items = new List<SyndicationItem>();

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:54570/MSUService.svc/notes?$filter=id%20eq%20" + studentId + "&$format=json");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseString = reader.ReadToEnd();
            Note[] notes = JsonConvert.DeserializeObject<NotesResponse>(responseString).value;
            foreach (var note in notes) {
                items.Add(new SyndicationItem(note.subj, note.note.ToString(), null));
            }
            feed.Items = items;

            // string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            SyndicationFeedFormatter formatter = new Atom10FeedFormatter(feed);

            return formatter;
        }
    }

    class Note {
        [JsonProperty("subject")]
        public string subj { get; set; }
        [JsonProperty("notes")]
        public int note { get; set; }
    }

    class NotesResponse {
        public Note[] value { get; set; }
    }
}
