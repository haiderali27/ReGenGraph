using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ReGenGraph
{
    class Graph {
        private List<Vertex> vertices;
        private Dictionary<String, List<Edge>> edges;

        private List<List<Vertex>> loveRule;
        /*private List<Edge> edges;*/
        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new Dictionary<string, List<Edge>>();
        }
        public Graph(List<Vertex> vertices)
        {
            this.vertices = vertices;
        }

        public Graph(List<Vertex> vertices, Dictionary<String, List<Edge>> edges) 
        {
            this.vertices = vertices;
            this.edges = edges;
        }
        public void DeleteVertex(int index)
        {
            Vertex vertex = vertices[index];
            foreach (Edge edge in vertex.GetEdges())
            {
                if (edge.GetSource() != vertex) {
                    edge.GetSource().GetEdges().Remove(edge);
                }

                if (edge.GetDest() != vertex)
                {
                    edge.GetDest().GetEdges().Remove(edge);
                }
            }

            vertices.RemoveAt(index - 1);
        }
        public void AddVertex(Vertex vertex) {
            if (vertex.GetIndex() < vertices.Count)
            {
                Console.WriteLine("Vertex with this index {0} already exists", vertex.GetIndex());
                return;
            }
            vertex.SetIndex(vertices.Count);
            vertices.Add(vertex);
        }
        public void AddVertex(String vertexLabel)
        {
            Vertex vertex = new Vertex();
            vertex.SetLabel(vertexLabel);
            vertex.SetIndex(vertices.Count);
            vertices.Add(vertex);
        }
        public List<Vertex> GetSourceVerticesByEdge(Vertex vertex, String relation, String reason)
        {
            List<Vertex> sourceVertices = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {

                if (edge.GetSource() != vertex && edge.GetRelation().Equals(relation) && edge.GetReason().Equals(reason))
                {
                    sourceVertices.Add(edge.GetSource());
                }
            }

            return sourceVertices;
        }
        public List<Vertex> GetDestVerticesByEdge(Vertex vertex, String relation, String reason)
        {
            List<Vertex> destVerticies = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {

                if (edge.GetDest() != vertex && edge.GetRelation().Equals(relation) && edge.GetReason().Equals(reason))
                {
                    destVerticies.Add(edge.GetDest());
                }
            }

            return destVerticies;
        }
        public List<Vertex> GetOtherVerticesByEdge(Vertex vertex, String relation, String reason)
        {
            List<Vertex> otherVertices = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {

                if (edge.GetSource() != vertex && edge.GetRelation().Equals(relation) && edge.GetReason().Equals(reason))
                {
                    otherVertices.Add(edge.GetSource());
                }
                if (edge.GetDest() != vertex && edge.GetRelation().Equals(relation) && edge.GetReason().Equals(reason))
                {
                    otherVertices.Add(edge.GetDest());
                }
            }

            return otherVertices;
        }
        public List<Vertex> GetSourceVerticesByEdgeRelation(Vertex vertex, String relation)
        {
            List<Vertex> sourceVertices = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {

                if (edge.GetSource() != vertex && edge.GetRelation().Equals(relation))
                {
                    sourceVertices.Add(edge.GetSource());
                }
            }

            return sourceVertices;
        }
        public List<Vertex> GetDestVerticesByEdgeRelation(Vertex vertex, String relation) {
            List<Vertex> destVerticies = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {

                if (edge.GetDest() != vertex && edge.GetRelation().Equals(relation))
                {
                    destVerticies.Add(edge.GetDest());
                }
            }

            return destVerticies;
        }
        public List<Vertex> GetOtherVerticesByEdgeRelation(Vertex vertex, String relation)
        {
            List<Vertex> otherVertices = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {

                if (edge.GetSource() != vertex && edge.GetRelation().Equals(relation))
                {
                    otherVertices.Add(edge.GetSource());
                }
                if (edge.GetDest() != vertex && edge.GetRelation().Equals(relation))
                {
                    otherVertices.Add(edge.GetDest());
                }
            }

            return otherVertices;
        }
        public List<Vertex> GetSourceVerticesByEdgeReason(Vertex vertex, String reason)
        {
            List<Vertex> sourceVertices = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {

                if (edge.GetSource() != vertex && edge.GetReason().Equals(reason))
                {
                    sourceVertices.Add(edge.GetSource());
                }
            }

            return sourceVertices;
        }
        public List<Vertex> GetDestVerticesByEdgeReason(Vertex vertex, String reason)
        {
            List<Vertex> destVerticies = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {

                if (edge.GetDest() != vertex && edge.GetReason().Equals(reason))
                {
                    destVerticies.Add(edge.GetDest());
                }
            }

            return destVerticies;
        }
        public List<Vertex> GetOtherVerticesByEdgeReason(Vertex vertex, String reason)
        {
            List<Vertex> otherVertices = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {

                if (edge.GetSource() != vertex && edge.GetReason().Equals(reason))
                {
                    otherVertices.Add(edge.GetSource());
                }
                if (edge.GetDest() != vertex && edge.GetReason().Equals(reason))
                {
                    otherVertices.Add(edge.GetDest());
                }
            }

            return otherVertices;
        }
        public List<Vertex> GetDestVertices(Vertex vertex) {
            List<Vertex> destVerticies = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {
             
                if (edge.GetDest() != vertex)
                {
                    destVerticies.Add(edge.GetDest());
                }
            }

            return destVerticies;
        }
        public List<Vertex> GetSourceVertices(Vertex vertex)
        {
            List<Vertex> sourceVerticies = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {

                if (edge.GetSource() != vertex)
                {
                    sourceVerticies.Add(edge.GetSource());
                }
            }

            return sourceVerticies;
        }
        public List<Vertex> GetOtherVertices(Vertex vertex)
        {
            List<Vertex> otherVerticies = new List<Vertex>();
            foreach (Edge edge in vertex.GetEdges())
            {

                if (edge.GetDest() != vertex)
                {
                    otherVerticies.Add(edge.GetDest());
                }
                if (edge.GetSource() != vertex)
                {
                    otherVerticies.Add(edge.GetSource());
                }
            }

            return otherVerticies;
        }
        public Vertex GetVertex(int index)
        {
            return vertices[index];
        }
        public void SetRelation(Vertex source, Vertex dest, String relation, String reason) {
            
            if (!this.vertices.Contains(source))
            {
                Console.WriteLine("source doesn't exist");
                return;
            }
            if (!this.vertices.Contains(dest))
            {
                Console.WriteLine("dest doesn't exist");
                return;
            }
            if (source.GetEdges().Contains(new Edge(source, dest, relation, reason)))
            {
                Console.WriteLine("This relation already exist");
                return;
            }
            if (dest.GetEdges().Contains(new Edge(source, dest, relation, reason)))
            {
                Console.WriteLine("This relation already exist");
                return;
            }
            source.AddEdges(new Edge(source, dest, relation, reason));
            dest.AddEdges(new Edge(source, dest, relation, reason));
        }
        /*Indexed Edged Settings*/
        public void SetIndexedEdgeRelation(Vertex source, Vertex dest, String relation, String reason)
        {

            if (!this.vertices.Contains(source))
            {
                Console.WriteLine("source doesn't exist");
                return;
            }
            if (!this.vertices.Contains(dest))
            {
                Console.WriteLine("dest doesn't exist");
                return;
            }
            String edgeKey = source.GetIndex().ToString() + "-" + dest.GetIndex().ToString();
            List<Edge> temp;
            if (this.edges.ContainsKey(edgeKey))
            {
                temp = this.edges[edgeKey];
                if(!temp.Contains(new Edge(source, dest, relation, reason)))
                {
                    temp.Add(new Edge(source, dest, relation, reason));
                    this.edges[edgeKey] = temp;
                }
                else
                {
                    Console.WriteLine("Same edge already exists");
                }
            }
            else
            {
                temp = new List<Edge>();
                temp.Add(new Edge(source, dest, relation, reason));
                this.edges.Add(edgeKey, temp);
                source.AddEdgeIndex(edgeKey);
                dest.AddEdgeIndex(edgeKey);
            }
            
           
            
          /*  source.AddEdgeIndex(currentEdgeIndex);
            dest.AddEdgeIndex(currentEdgeIndex);
            this.edges.Add(new Edge(source, dest, relation, reason));*/
        }
        public void DeleteIndexedEdgeRelation(String edgeKey, Edge edge) {
            if (this.edges.ContainsKey(edgeKey))
            {
                if (this.edges[edgeKey].Count == 1)
                {
                    this.edges[edgeKey][0].GetDest().GetEdgeIndices().Remove(edgeKey);
                    this.edges[edgeKey][0].GetSource().GetEdgeIndices().Remove(edgeKey);
                    this.edges.Remove(edgeKey);
                }
                else
                {
                    List<Edge> temp = this.edges[edgeKey];
                    temp.Remove(edge);
                    this.edges[edgeKey] = temp;
                }
            }
        }
        public void DeleteIndexedEdgeRelations(String edgeKey)
        {
            if (this.edges.ContainsKey(edgeKey))
            {
                    this.edges[edgeKey][0].GetDest().GetEdgeIndices().Remove(edgeKey);
                    this.edges[edgeKey][0].GetSource().GetEdgeIndices().Remove(edgeKey);
                    this.edges.Remove(edgeKey);   
            }
        }
        public void DeleteIndexedEdgeVertex(int index)
        {
            Vertex vertex = vertices[index];
            List<String> edgeKeys = vertex.GetEdgeIndices();
            foreach(String edgeKey in edgeKeys)
            {
                if(!this.edges[edgeKey][0].GetDest().Equals(vertex))
                    this.edges[edgeKey][0].GetDest().GetEdgeIndices().Remove(edgeKey);
                if (!this.edges[edgeKey][0].GetSource().Equals(vertex))
                    this.edges[edgeKey][0].GetSource().GetEdgeIndices().Remove(edgeKey);
                
                this.edges.Remove(edgeKey);
            }
            vertices.RemoveAt(index - 1);
        }
        public void DeleteIndexedRelationShipByRelation(String edgeIndex, String relation)
        {
            if (!this.edges.ContainsKey(edgeIndex))
            {
                Console.WriteLine("Edge Doesn't Exist");
                return;
            }
            foreach (Edge edge in this.edges[edgeIndex])
            {
                if (edge.GetRelation().Equals(relation))
                {
                    this.edges[edgeIndex].Remove(edge);
                    if (this.edges[edgeIndex].Count == 0)
                    {
                        edge.GetSource().GetEdgeIndices().Remove(edgeIndex);
                        edge.GetDest().GetEdgeIndices().Remove(edgeIndex);
                    }
                }
            }
        }
        public void DeleteIndexedRelationShipByReason(String edgeIndex, String reason)
        {
            if (!this.edges.ContainsKey(edgeIndex))
            {
                Console.WriteLine("Edge Doesn't Exist");
                return;
            }
            foreach (Edge edge in this.edges[edgeIndex])
            {
                if (edge.GetRelation().Equals(reason))
                {
                    this.edges[edgeIndex].Remove(edge);
                    if (this.edges[edgeIndex].Count == 0)
                    {
                        edge.GetSource().GetEdgeIndices().Remove(edgeIndex);
                        edge.GetDest().GetEdgeIndices().Remove(edgeIndex);
                    }
                }
            }
        }
        public void DeleteIndexedRelationShipByRelationAndReason(String edgeIndex, String relation, String reason)
        {
            if (!this.edges.ContainsKey(edgeIndex))
            {
                Console.WriteLine("Edge Doesn't Exist");
                return;
            }
            foreach (Edge edge in this.edges[edgeIndex])
            {
                if (edge.GetRelation().Equals(relation) && edge.GetReason().Equals(reason))
                {
                    this.edges[edgeIndex].Remove(edge);
                    if (this.edges[edgeIndex].Count == 0)
                    {
                        edge.GetSource().GetEdgeIndices().Remove(edgeIndex);
                        edge.GetDest().GetEdgeIndices().Remove(edgeIndex);
                    }
                }
            }
        }
        public List<Vertex> GetSourceVerticesByIndexedEdge(Vertex vertex, String relation, String reason)
        {
            List<Vertex> sourceVertices = new List<Vertex>();
            foreach(String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[1].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation)&& this.edges[edgeKey][i].GetReason().Equals(reason))
                        {
                            sourceVertices.Add(this.edges[edgeKey][0].GetSource());
                            flag = true;
                        }
                        i++;
                        
                    }
                }
            }
            return sourceVertices;
        }
        public List<Vertex> GetDestVerticesByIndexedEdge(Vertex vertex, String relation, String reason)
        {
            List<Vertex> destVerticies = new List<Vertex>();
            foreach (String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[0].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation) && this.edges[edgeKey][i].GetReason().Equals(reason))
                        {
                            destVerticies.Add(this.edges[edgeKey][0].GetDest());
                            flag = true;
                        }
                        i++;
                    }
                }
            }

            return destVerticies;
        }
        public List<Vertex> GetOtherVerticesByIndexedEdge(Vertex vertex, String relation, String reason)
        {
            List<Vertex> otherVertices = new List<Vertex>();
            foreach (String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[1].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation) && this.edges[edgeKey][i].GetReason().Equals(reason))
                        {
                            otherVertices.Add(this.edges[edgeKey][0].GetSource());
                            flag = true;
                        }
                        i++;

                    }
                }
                if (edgeKey.Split("-")[0].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation) && this.edges[edgeKey][i].GetReason().Equals(reason))
                        {
                            otherVertices.Add(this.edges[edgeKey][0].GetDest());
                            flag = true;
                        }
                        i++;
                    }
                }
            }
            return otherVertices;
        }

        public List<Vertex> GetSourceVerticesByIndexedEdgeByRelation(Vertex vertex, String relation)
        {
            List<Vertex> sourceVertices = new List<Vertex>();
            foreach (String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[1].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation))
                        {
                            sourceVertices.Add(this.edges[edgeKey][0].GetSource());
                            flag = true;
                        }
                        i++;

                    }
                }
            }
            return sourceVertices;
        }
        public List<Vertex> GetDestVerticesByIndexedEdgeByRelation(Vertex vertex, String relation)
        {
            List<Vertex> destVerticies = new List<Vertex>();
            foreach (String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[0].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation))
                        {
                            destVerticies.Add(this.edges[edgeKey][0].GetDest());
                            flag = true;
                        }
                        i++;
                    }
                }
            }

            return destVerticies;
        }
        public List<Vertex> GetOtherVerticesByIndexedEdge(Vertex vertex, String relation)
        {
            List<Vertex> otherVertices = new List<Vertex>();
            foreach (String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[1].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation))
                        {
                            otherVertices.Add(this.edges[edgeKey][0].GetSource());
                            flag = true;
                        }
                        i++;

                    }
                }
                if (edgeKey.Split("-")[0].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation))
                        {
                            otherVertices.Add(this.edges[edgeKey][0].GetDest());
                            flag = true;
                        }
                        i++;
                    }
                }
            }
            return otherVertices;
        }
        public List<Vertex> GetSourceVerticesByIndexedEdgeByReason(Vertex vertex, String reason)
        {
            List<Vertex> sourceVertices = new List<Vertex>();
            foreach (String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[1].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetReason().Equals(reason))
                        {
                            sourceVertices.Add(this.edges[edgeKey][0].GetSource());
                            flag = true;
                        }
                        i++;

                    }
                }
            }
            return sourceVertices;
        }
        public List<Vertex> GetDestVerticesByIndexedEdgeByReason(Vertex vertex, String reason)
        {
            List<Vertex> destVerticies = new List<Vertex>();
            foreach (String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[0].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetReason().Equals(reason))
                        {
                            destVerticies.Add(this.edges[edgeKey][0].GetDest());
                            flag = true;
                        }
                        i++;
                    }
                }
            }

            return destVerticies;
        }
        public List<Vertex> GetOtherVerticesByIndexedEdgeByReason(Vertex vertex, String reason)
        {
            List<Vertex> otherVertices = new List<Vertex>();
            foreach (String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[1].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetReason().Equals(reason))
                        {
                            otherVertices.Add(this.edges[edgeKey][0].GetSource());
                            flag = true;
                        }
                        i++;

                    }
                }
                if (edgeKey.Split("-")[0].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    bool flag = false;
                    while (i < this.edges[edgeKey].Count && flag == false)
                    {
                        if (this.edges[edgeKey][i].GetReason().Equals(reason))
                        {
                            otherVertices.Add(this.edges[edgeKey][0].GetDest());
                            flag = true;
                        }
                        i++;
                    }
                }
            }
            return otherVertices;
        }
        public bool RelationExistsWithOtherSource(Vertex vertex, String relation)
        {
            bool exists = false;
            foreach (String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[1].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    while (i < this.edges[edgeKey].Count && exists == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation))
                        {

                            exists = true;
                        }
                        i++;

                    }
                }
            }
            return exists;
        }
        public bool RelationExistsWithOtherDestination(Vertex vertex, String relation)
        {
            bool exists = false;
            foreach (String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[0].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    while (i < this.edges[edgeKey].Count && exists == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation))
                        {
                            exists = true;
                        }
                        i++;

                    }
                }
            }
            return exists;
        }
        public bool RelationExistsWithOtherVertex(Vertex vertex, String relation)
        {
            bool exists = false;
            foreach (String edgeKey in vertex.GetEdgeIndices())
            {
                if (edgeKey.Split("-")[0].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    while (i < this.edges[edgeKey].Count && exists == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation))
                        {
                            exists = true;
                        }
                        i++;

                    }
                }
                if (edgeKey.Split("-")[1].Equals(vertex.GetIndex().ToString()))
                {
                    int i = 0;
                    while (i < this.edges[edgeKey].Count && exists == false)
                    {
                        if (this.edges[edgeKey][i].GetRelation().Equals(relation))
                        {
                            exists = true;
                        }
                        i++;

                    }
                }
            }
            return exists;
        }
        public void LoveRule()
        {
            List<Vertex> temp;
            this.loveRule = new List<List<Vertex>>();
            foreach (Vertex vertex in this.vertices)
            {
                List<Vertex> destVertices = GetDestVerticesByIndexedEdgeByRelation(vertex, "loves");
                temp = new List<Vertex>();
                foreach (Vertex vertex1 in destVertices)
                {
                    if (!GetDestVerticesByIndexedEdgeByRelation(vertex1, "loves").Contains(vertex))
                    {
                        if(RelationExistsWithOtherDestination(vertex1, "loves"))
                        {
                            temp.Add(vertex);
                            temp.Add(vertex1);
                            temp.Add(GetDestVerticesByIndexedEdgeByRelation(vertex1, "loves")[0]);
                        }
                       
                    }
                    this.loveRule.Add(temp);
                }
            }
        }
        public void PrintLoveRule() { 
            foreach(List<Vertex> vertices in this.loveRule)
            {
                Console.WriteLine("\n=======\n");
                int i = 0;
                foreach(Vertex vertex in vertices) {
                    if (i ==0 || i==1)
                    {
                        Console.Write(vertex.GetLabel()+ " loves ");
                    }
                    else {
                        Console.WriteLine(vertex.GetLabel());
                    }
                    i++;
                }
            }
        }
        public Graph GetGraph() 
        {
            return this;
        }
    }

   

    class Attributes
    {
        private String name;
        private int rank;
        public Attributes() {
            name = null;
            rank = 0;
        }
        public Attributes(String name, int rank)
        {
            this.name = name;
            this.rank = rank;
        }
        public void SetAttributes(String name, int rank) {
            this.name = name;
            this.rank = rank;
        }
        public Attributes GetAttributes() {
            return this;
        }
        public void SetName(String name) {
            this.name = name;
        }
        public void SetRank(int rank) {
            this.rank = rank;
        }
        public String GetName() {
            return this.name;
        }
        public int GetRank() {
            return this.rank;
        }

    }
    class Vertex {
        private String label;
        private int index = 1;
        private Attributes attributes;
        private List<String> edgeIncides;
        List<Edge> edges;
        public Vertex() {
            this.label = null;
            this.edgeIncides = new List<String>();
            this.edges = new List<Edge>();
            this.attributes = null;
            this.index = 0;
        }

        public void AddEdgeIndex(String index)
        {
            this.edgeIncides.Add(index);
        }
        public void AddEdges(Edge edge)
        {
            this.edges.Add(edge);
        }
        public void SetEdgeIndices(List<String> edgeIncides)
        {
            this.edgeIncides = edgeIncides;
        }
        public List<String> GetEdgeIndices() {
            return this.edgeIncides;
        }
        public Edge GetEdge(int index)
        {
            return edges[index];
        }
        public void SetVertex(String label, Attributes attributes, List<Edge> edges) {
            this.label = label;
            this.attributes = attributes;
            this.edges = edges;
        }

        public void SetLabel(String label) {
            this.label = label;
        }
        public String GetLabel()
        {
            return this.label;
        }
        public void SetAttributes(Attributes attributes) {
            this.attributes = attributes;
        }
        public Attributes GetAttributes()
        {
            return this.attributes;
        }
        public void SetEdges(List<Edge> edges)
        {
            this.edges = edges;
        }
        public List<Edge> GetEdges() {
            return this.edges;
        }

        public int GetEdgeCount() {
            return this.edges.Count;
        }
        public int GetDifferentDestCount()
        {
            int count = 0;
            foreach(Edge edge in this.edges)
            {
                if (edge.GetDest() != this)
                {
                    count++;
                }
            }
            return count;
        }
        public Vertex GetVertex()
        {
            return this;
        }

        public int GetIndex() {
            return this.index;
        }
        public void SetIndex(int index)
        {
            this.index=index+1;
        }
        public override int GetHashCode()
        {
            return this.index;
        }
        public override bool Equals(Object obj)
        {
            return (obj is Vertex) && ((Vertex)obj).index == index;
        }
    }
    class Edge {
        private String relation, reason;
        private Vertex source, dest;
        public Edge() {
            this.source = this.dest  = null;
            this.relation = this.reason = null;
        }
        public String GetReason()
        {
            return this.reason;
        }
        public String GetRelation() {
            return this.relation;
        }
        public Edge(Vertex source, Vertex dest, String relation, String reason) {
            this.source = source;
            this.dest = dest;
            this.relation = relation;
            this.reason = reason;
        }

        public void GetEdge(Vertex source, Vertex dest, String relation, String reason)
        {
            this.source = source;
            this.dest = dest;
            this.relation = relation;
            this.reason = reason;
        }
        public Vertex GetSource() {
            return this.source;
        }
        public Vertex GetDest() {
            return this.dest;
        }
        public Edge GetEdge()
        {
            return this;
        }
        public override int GetHashCode()
        {
            int result = this.source.GetHashCode() ^ this.dest.GetHashCode() ^ this.relation.GetHashCode() ^ this.reason.GetHashCode();
            return result;
        }
        public override bool Equals(Object obj)
        {
            return (obj is Edge) && ((Edge)obj).source ==source && ((Edge)obj).dest == dest && ((Edge)obj).relation == relation && ((Edge)obj).reason == reason;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Graph graph = new Graph();
            for(int i = 0; i < 5; i++)
            {
                graph.AddVertex("NODE_" + i.ToString());
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Label value: " + graph.GetVertex(i).GetLabel());
            }
            Vertex vertex1 = new Vertex();
            graph.AddVertex(vertex1);
            
            graph.SetRelation(graph.GetVertex(0), graph.GetVertex(4), "competess", "enemy");
            
            Console.WriteLine(graph.GetVertex(0).GetEdge(0).GetDest().GetLabel()+", "+graph.GetVertex(0).GetEdge(0).GetDest().GetIndex());
            Console.WriteLine(graph.GetVertex(0).GetEdge(0).GetDest().GetLabel() + ", " + graph.GetVertex(1).GetIndex());
            graph.DeleteVertex(1);
            Console.WriteLine(graph.GetVertex(0).GetLabel());
            Graph graph1 = new Graph();
            graph1.AddVertex("N1");
            graph1.AddVertex("N2");
            graph1.AddVertex("N3");
            graph1.AddVertex("N4");
            graph1.SetRelation(graph1.GetVertex(0), graph1.GetVertex(1), "loves", "nice");
            graph1.SetRelation(graph1.GetVertex(0), graph1.GetVertex(0), "loves", "no reason");
            Console.WriteLine(graph1.GetVertex(1).GetEdge(0).GetReason());*/
            
            
            Graph graph2 = new Graph();
            graph2.AddVertex("B1");
            graph2.AddVertex("B2");
            graph2.AddVertex("B3");
            graph2.AddVertex("B4");
            graph2.AddVertex("B5");
            graph2.AddVertex("B6");
            graph2.AddVertex("B7");
            graph2.SetIndexedEdgeRelation(graph2.GetVertex(0), graph2.GetVertex(1), "loves", "some");
            graph2.SetIndexedEdgeRelation(graph2.GetVertex(1), graph2.GetVertex(2), "loves", "some");
            graph2.SetIndexedEdgeRelation(graph2.GetVertex(2), graph2.GetVertex(3), "loves", "some");
            graph2.SetIndexedEdgeRelation(graph2.GetVertex(3), graph2.GetVertex(5), "loves", "some");
            graph2.LoveRule();
            graph2.PrintLoveRule(); 
            //Console.WriteLine("Graph2: " + graph2.GetVertex(0).GetEdgeIndices()[1]);
        }
    }
}
