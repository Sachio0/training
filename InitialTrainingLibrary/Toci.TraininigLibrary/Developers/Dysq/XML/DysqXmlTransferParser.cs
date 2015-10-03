﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.TraininigLibrary.Common.FileParser;
using Toci.TraininigLibrary.Developers.Dysq.FileParser;
using Toci.TraininigLibrary.Developers.Dysq.XMLBase;
using Toci.TraininigLibrary.Developers.Dysq.XML;

namespace Toci.TraininigLibrary.Developers.Dysq.XML
{
    public class DysqXmlTransferParser : DysqTransfersParserBase
    {
        public override List<DysqFileEntityPolymorphism> GetTransfers(string path)
        {
            XmlDysqParser<DysqFileEntityPolymorphismTransfers> xmlDysqParser =
                new XmlDysqParser<DysqFileEntityPolymorphismTransfers>();
            var myresult = xmlDysqParser.DysqGetXmlData(path);


            return myresult.DysqTransfersList.ToList();

        }
    }
}