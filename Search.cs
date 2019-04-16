using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CommonServiceLocator;
using Solr.Models;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace Solr
{
    public class Search
    {
        public Search() {
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Post>>();
            QueryOptions query_options = new QueryOptions
            {
            Rows = 10,
            StartOrCursor = new StartOrCursor.Start(0),
            FilterQueries = new ISolrQuery[] {
                new SolrQueryByField("postTypeId", "1"),
                }
            };
            while(true) {
                Console.WriteLine("Query:");
                string keywords = Console.ReadLine();
                // Construct the query
                SolrQuery query = new SolrQuery(keywords);
                // Run a basic keyword search, filtering for questions only
                List<Post> posts = solr.Query(query, query_options);
                foreach(Post p in posts) {
                    Console.WriteLine(p.Title);
                }
            }
        }
    }
}