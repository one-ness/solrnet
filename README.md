# solrnet
### setup
1. Download/install Solr
2. Starup Solr from command-line: "bin/solr start" in solr directory
3. Open the adminUI at "http://localhost:8983/solr"
4. Create a new core named "msdnarticledemo"
    - move the msdnarticledemo folder from vscode directory to solr directory: "/solr/8.0.0/server/solr/"
    - switch to solr directory "/solr/8.0.0/"
    - create core: "bin/solr create_core -c msdnarticledemo -d server/solr/msdnarticledemo/conf"
5. Install package in VScodewith nuget: "dotnet add package SolrNet --version 1.0.15"

### running
1. For the first run, uncomment "Indexer index = new Indexer()" on line 22 in file "Program.cs", this will index the documents (for subsequent runs, comment it out, otherwise the data will have duplicated indexing)
2. Enter queries in integrated terminal (ex: "Machine Learning") or using Postman (ex: "http://localhost:8983/solr/msdnarticledemo/select?q=%2BMachine%20%2BLearning")
