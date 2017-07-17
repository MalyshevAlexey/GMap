using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;

namespace GMap.Models
{
    public class MapManager
    {
        public string Lat { get; private set; }
        public string Lng { get; private set; }

        const string url = "http://maps.google.com/maps/api/geocode/xml?address=";
        const string path = "GeocodeResponse/result/geometry/location";
        const string proxy = "http://10.1.126.166:8080";

        public bool ParseAddress(string address)
        {
            try
            {
                WebProxy wp = new WebProxy(proxy, true);
                wp.Credentials = CredentialCache.DefaultCredentials;
                WebClient wc = new WebClient();
                wc.Proxy = wp;
                MemoryStream ms = new MemoryStream(wc.DownloadData(url + address));
                XmlTextReader rdr = new XmlTextReader(ms);
                XmlDocument xml = new XmlDocument();
                xml.Load(rdr);
                XmlNode node = xml.SelectSingleNode(path);
                if (node == null) return false;
                Lat = node.ChildNodes[0].InnerText.Trim();
                Lng = node.ChildNodes[1].InnerText.Trim();
                return true;
            }
            catch (Exception ex)
            {
                Lat = "0 " + ex.Message;
                Lng = "0";
                return false;
            }
        }
    }
}