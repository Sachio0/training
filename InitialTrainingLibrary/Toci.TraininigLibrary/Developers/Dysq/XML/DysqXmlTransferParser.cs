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
        public override List<FileEntityBase> GetTransfers(string path)
        {
            XmlDysqParser<DysqXmlTransfers> xmlDysqParser = new XmlDysqParser<DysqXmlTransfers>();
            var myresult = xmlDysqParser.DysqGetXmlData(path);

             myresult.DysqXmlTrasfersList.ToList();

            List<FileEntityBase> finalResult = new List<FileEntityBase>();

            foreach (var item in myresult.DysqXmlTrasfersList)
            {
                finalResult.Add(new DysqFileEntity() 
                { Account = item.SourceAccount, Name = item.Name, Date = Convert.ToDateTime(item.DateOfTransaction), Surname = item.Surname });
            }

            return finalResult;
        }
    }
}