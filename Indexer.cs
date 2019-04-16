using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CommonServiceLocator;
using Solr.Models;
using SolrNet;

namespace Solr
{
    public class Indexer
    {
        public Indexer() {
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Post>>();
            string path = "/Users/oneness/datascience_data/Posts.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes =  doc.DocumentElement.SelectNodes("/posts/row");
            List<Post> list = new List<Post>();
            foreach(XmlNode node in nodes) {
                if(list.Count == 100) {
                    solr.AddRange(list);
                    list = new List<Post>();
                }
                Post post = new Post();
                post.Id = node.Attributes["Id"].Value;
                if(node.Attributes["Title"] != null)
                {
                    post.Title = node.Attributes["Title"].Value;
                }
                if(node.Attributes["Tags"] != null){
                    post.Tags = node.Attributes["Tags"].Value.Split(new char[] { '<', '>' })
                        .Where(t => !string.IsNullOrEmpty(t)).ToList();
                }
                if(node.Attributes["PostTypeId"] != null) {
                    post.PostTypeId = int.Parse(node.Attributes["PostTypeId"].Value);
                }
                if(node.Attributes["CreationDate"] != null) {
                    post.CreationDate = DateTime.Parse(node.Attributes["CreationDate"].Value);
                }
                if(node.Attributes["LastActivityDate"] != null) {
                    post.LastActivityDate = DateTime.Parse(node.Attributes["LastActivityDate"].Value);
                }
                if(node.Attributes["Score"] != null) {
                    post.PostScore = float.Parse(node.Attributes["Score"].Value);
                }
                if(node.Attributes["ViewCount"] != null) {
                    post.ViewCount = int.Parse(node.Attributes["ViewCount"].Value);
                }
                if(node.Attributes["OwnerUserId"] != null) {
                    post.OwnerUserId = int.Parse(node.Attributes["OwnerUserId"].Value);
                }
                if(node.Attributes["AnswerCount"] != null) {
                    post.AnswerCount = int.Parse(node.Attributes["AnswerCount"].Value);
                }
                if(node.Attributes["CommentCount"] != null) {
                    post.CommentCount = int.Parse(node.Attributes["CommentCount"].Value);
                }
                if(node.Attributes["FavoriteCount"] != null) {
                    post.FavoriteCount = int.Parse(node.Attributes["FavoriteCount"].Value);
                }
                if(node.Attributes["ClosedDate"] != null) {
                    post.ClosedDate = DateTime.Parse(node.Attributes["ClosedDate"].Value);
                }
                if(node.Attributes["Body"] != null) {
                    post.Body = node.Attributes["Body"].Value;
                }
                list.Add(post);
            }
            solr.AddRange(list);
            solr.Commit();
        }
    }
}