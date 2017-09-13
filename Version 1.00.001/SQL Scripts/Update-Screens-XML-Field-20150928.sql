USE [iops_dev]
GO

ALTER TABLE Screens ADD DefaultDisplayOrder INT NULL, DefaultIconType NVARCHAR(50) NULL 

--SCRIPT USED TO CREATE THE INITIAL UPDATE Screens commands, WARNING: Change all ? to appropriate values and VALIDATE all the information thoroughly
--SELECT
--      'UPDATE Screens SET ScreenLayout = ''<Screen-Layout Version="1.0.0"><AjaxUrl>' +
--		CASE 
--			WHEN Name LIKE '%Term%' THEN '/Airport/Airport/Show' + SUBSTRING(Name,1,3) + 'Airport</AjaxUrl><AjaxData>{''''clientName'''':''''' + SUBSTRING(Name,1,3) + '''''}</AjaxData><TagPrefix>' + CASE SUBSTRING(Name,1,3) WHEN 'CID' THEN '\\opc.iopsnow.com\RemoteSCADAHosting.' WHEN 'JFK' THEN '\\\\10.28.100.3\' WHEN 'SLL' THEN '\\\\10.174.20.82\' WHEN 'RDU' THEN '\\10.10.101.34\' WHEN 'SWA' THEN '\\69.60.110.8\SouthWest.DAL.' END + 'Airport.' + SUBSTRING(Name,1,3) + '.</TagPrefix>' 
--			WHEN Name LIKE '%Zone%' THEN '/Zones/Zones/Show' + SUBSTRING(Name,1,3) + 'Zone</AjaxUrl><AjaxData>{''''zoneNum'''':''''' + REPLACE(Name,SUBSTRING(Name,1,3)+'Zone','') +'''''}</AjaxData><TagPrefix>' + CASE SUBSTRING(Name,1,3) WHEN 'CID' THEN '\\opc.iopsnow.com\RemoteSCADAHosting.' WHEN 'JFK' THEN '\\\\10.28.100.3\' WHEN 'SLL' THEN '\\\\10.174.20.82\' WHEN 'RDU' THEN '\\10.10.101.34\' WHEN 'SWA' THEN '\\69.60.110.8\SouthWest.DAL.' END + 'Airport.' + SUBSTRING(Name,1,3) + '.Term4.Zone' + REPLACE(Name,SUBSTRING(Name,1,3)+'Zone','') +'.</TagPrefix>' 
--			WHEN Name LIKE '%Gate%' THEN '/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''''zoneNum'''':''''?'''',''''gateNum'''':''''' + REPLACE(Name,SUBSTRING(Name,1,3)+'Gate','') + '''''}</AjaxData><TagPrefix>' + CASE SUBSTRING(Name,1,3) WHEN 'CID' THEN '\\opc.iopsnow.com\RemoteSCADAHosting.' WHEN 'JFK' THEN '\\\\10.28.100.3\' WHEN 'SLL' THEN '\\\\10.174.20.82\' WHEN 'RDU' THEN '\\10.10.101.34\' WHEN 'SWA' THEN '\\69.60.110.8\SouthWest.DAL.' END + 'Airport.' + SUBSTRING(Name,1,3) + '.Term?.Zone?.Gate' + REPLACE(Name,SUBSTRING(Name,1,3)+'Gate','')  +'.</TagPrefix>' 
--			WHEN Name LIKE '%Network%' THEN '/Gate/Gate/ShowNetwork</AjaxUrl><AjaxData>{''''clientName'''':''''' + SUBSTRING(Name,1,3) + '''''}</AjaxData><TagPrefix>' + CASE SUBSTRING(Name,1,3) WHEN 'CID' THEN '\\opc.iopsnow.com\RemoteSCADAHosting.' WHEN 'JFK' THEN '\\\\10.28.100.3\' WHEN 'SLL' THEN '\\\\10.174.20.82\' WHEN 'RDU' THEN '\\10.10.101.34\' WHEN 'SWA' THEN '\\69.60.110.8\SouthWest.DAL.' END + 'Network.' + SUBSTRING(Name,1,3) + '.</TagPrefix>' 
--		END + '</Screen-Layout>'', DefaultDisplayOrder = 1, DefaultIconType = ''' + CASE WHEN Name LIKE '%Term%' THEN + 'Airport' WHEN Name LIKE '%Zone%' THEN + 'Zone' WHEN Name LIKE '%Gate%' THEN + 'Gate' WHEN Name LIKE '%Network%' THEN + 'Network' END + ''' WHERE Name = ''' + [Name] + ''''

--  FROM [dbo].[Screens]
--  ORDER BY Name


UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''1''}</AjaxData><TagPrefix>\\opc.iopsnow.com\RemoteSCADAHosting.Airport.CID.Term1.Zone1.Gate C-1.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 2, DefaultIconType = 'Gate' WHERE Name = 'CIDGate001'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''2''}</AjaxData><TagPrefix>\\opc.iopsnow.com\RemoteSCADAHosting.Airport.CID.Term1.Zone1.Gate C-2.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 3, DefaultIconType = 'Gate' WHERE Name = 'CIDGate002'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''3''}</AjaxData><TagPrefix>\\opc.iopsnow.com\RemoteSCADAHosting.Airport.CID.Term1.Zone1.Gate C-3.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 4, DefaultIconType = 'Gate' WHERE Name = 'CIDGate003'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''4''}</AjaxData><TagPrefix>\\opc.iopsnow.com\RemoteSCADAHosting.Airport.CID.Term1.Zone1.Gate C-4.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 5, DefaultIconType = 'Gate' WHERE Name = 'CIDGate004'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''5''}</AjaxData><TagPrefix>\\opc.iopsnow.com\RemoteSCADAHosting.Airport.CID.Term1.Zone1.Gate C-5.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 6, DefaultIconType = 'Gate' WHERE Name = 'CIDGate005'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''6''}</AjaxData><TagPrefix>\\opc.iopsnow.com\RemoteSCADAHosting.Airport.CID.Term1.Zone1.Gate C-6.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 7, DefaultIconType = 'Gate' WHERE Name = 'CIDGate006'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''7''}</AjaxData><TagPrefix>\\opc.iopsnow.com\RemoteSCADAHosting.Airport.CID.Term1.Zone1.Gate C-7.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 8, DefaultIconType = 'Gate' WHERE Name = 'CIDGate007'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Airport/Airport/ShowAirport</AjaxUrl><AjaxData>{''clientName'':''CID'',''numberOfScreens'':''8''}</AjaxData><TagPrefix>\\opc.iopsnow.com\RemoteSCADAHosting.Airport.CID.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 1, DefaultIconType = 'Airport' WHERE Name = 'CIDTerm'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''A1'',''gateNum'':''A5''}</AjaxData><TagPrefix>\\\\10.28.100.3\Airport.JFK.Term4.ZoneA1.GateA5.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 6, DefaultIconType = 'Gate' WHERE Name = 'JFKGateA5'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''B1'',''gateNum'':''B25L1''}</AjaxData><TagPrefix>\\\\10.28.100.3\Airport.JFK.Term4.ZoneB1.GateB25L1.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 7, DefaultIconType = 'Gate' WHERE Name = 'JFKGateB25L1'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''B1'',''gateNum'':''B27''}</AjaxData><TagPrefix>\\\\10.28.100.3\Airport.JFK.Term4.ZoneB1.GateB27.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 8, DefaultIconType = 'Gate' WHERE Name = 'JFKGateB27'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Airport/Airport/ShowAirport</AjaxUrl><AjaxData>{''clientName'':''JFK'',''numberOfScreens'':''8''}</AjaxData><TagPrefix>\\\\10.28.100.3\Airport.JFK.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 1, DefaultIconType = 'Airport' WHERE Name = 'JFKTerm'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Zones/Zones/ShowJFKZone</AjaxUrl><AjaxData>{''zoneNum'':''A1''}</AjaxData><TagPrefix>\\\\10.28.100.3\Airport.JFK.Term4.ZoneA1.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 2, DefaultIconType = 'Zone' WHERE Name = 'JFKZoneA1'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Zones/Zones/ShowJFKZone</AjaxUrl><AjaxData>{''zoneNum'':''B1''}</AjaxData><TagPrefix>\\\\10.28.100.3\Airport.JFK.Term4.ZoneB1.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 3, DefaultIconType = 'Zone' WHERE Name = 'JFKZoneB1'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Zones/Zones/ShowJFKZone</AjaxUrl><AjaxData>{''zoneNum'':''B2''}</AjaxData><TagPrefix>\\\\10.28.100.3\Airport.JFK.Term4.ZoneB2.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 4, DefaultIconType = 'Zone' WHERE Name = 'JFKZoneB2'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Zones/Zones/ShowJFKZone</AjaxUrl><AjaxData>{''zoneNum'':''B3''}</AjaxData><TagPrefix>\\\\10.28.100.3\Airport.JFK.Term4.ZoneB3.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 5, DefaultIconType = 'Zone' WHERE Name = 'JFKZoneB3'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''1''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate1.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 2, DefaultIconType = 'Gate' WHERE Name = 'RDUGate001'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''2''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate2.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 3, DefaultIconType = 'Gate' WHERE Name = 'RDUGate002'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''3''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate3.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 4, DefaultIconType = 'Gate' WHERE Name = 'RDUGate003'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''4''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate4.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 5, DefaultIconType = 'Gate' WHERE Name = 'RDUGate004'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''5''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate5.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 6, DefaultIconType = 'Gate' WHERE Name = 'RDUGate005'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''6''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate6.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 7, DefaultIconType = 'Gate' WHERE Name = 'RDUGate006'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''7''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate7.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 8, DefaultIconType = 'Gate' WHERE Name = 'RDUGate007'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''8''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate8.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 9, DefaultIconType = 'Gate' WHERE Name = 'RDUGate008'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''9''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate9.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 10, DefaultIconType = 'Gate' WHERE Name = 'RDUGate009'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''10''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate10.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 11, DefaultIconType = 'Gate' WHERE Name = 'RDUGate010'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''11''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate11.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 12, DefaultIconType = 'Gate' WHERE Name = 'RDUGate011'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''12''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate12.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 13, DefaultIconType = 'Gate' WHERE Name = 'RDUGate012'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''13''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate13.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 14, DefaultIconType = 'Gate' WHERE Name = 'RDUGate013'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''14''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate14.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 15, DefaultIconType = 'Gate' WHERE Name = 'RDUGate014'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''15''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate15.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 16, DefaultIconType = 'Gate' WHERE Name = 'RDUGate015'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''16''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate16.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 17, DefaultIconType = 'Gate' WHERE Name = 'RDUGate016'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''17''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate17.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 18, DefaultIconType = 'Gate' WHERE Name = 'RDUGate017'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''18''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate18.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 19, DefaultIconType = 'Gate' WHERE Name = 'RDUGate018'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''19''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate19.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 20, DefaultIconType = 'Gate' WHERE Name = 'RDUGate019'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''20''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate20.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 21, DefaultIconType = 'Gate' WHERE Name = 'RDUGate020'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''21''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate21.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 22, DefaultIconType = 'Gate' WHERE Name = 'RDUGate021'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''22''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate22.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 23, DefaultIconType = 'Gate' WHERE Name = 'RDUGate022'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''23''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate23.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 24, DefaultIconType = 'Gate' WHERE Name = 'RDUGate023'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''24''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate24.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 25, DefaultIconType = 'Gate' WHERE Name = 'RDUGate024'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''25''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate25.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 26, DefaultIconType = 'Gate' WHERE Name = 'RDUGate025'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''26''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate26.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 27, DefaultIconType = 'Gate' WHERE Name = 'RDUGate026'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''27''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate27.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 28, DefaultIconType = 'Gate' WHERE Name = 'RDUGate027'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''28''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate28.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 29, DefaultIconType = 'Gate' WHERE Name = 'RDUGate028'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''29''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate29.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 30, DefaultIconType = 'Gate' WHERE Name = 'RDUGate029'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''30''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate30.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 31, DefaultIconType = 'Gate' WHERE Name = 'RDUGate030'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''31''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate31.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 32, DefaultIconType = 'Gate' WHERE Name = 'RDUGate031'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''32''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate32.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 33, DefaultIconType = 'Gate' WHERE Name = 'RDUGate032'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''33''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate33.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 34, DefaultIconType = 'Gate' WHERE Name = 'RDUGate033'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''34''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate34.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 35, DefaultIconType = 'Gate' WHERE Name = 'RDUGate034'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''35''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate35.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 36, DefaultIconType = 'Gate' WHERE Name = 'RDUGate035'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''36''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate36.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 37, DefaultIconType = 'Gate' WHERE Name = 'RDUGate036'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''37''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate37.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 38, DefaultIconType = 'Gate' WHERE Name = 'RDUGate037'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''38''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate38.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 39, DefaultIconType = 'Gate' WHERE Name = 'RDUGate038'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''39''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate39.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 40, DefaultIconType = 'Gate' WHERE Name = 'RDUGate039'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''40''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.Term1.Zone1.Gate40.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 41, DefaultIconType = 'Gate' WHERE Name = 'RDUGate040'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Airport/Airport/ShowAirport</AjaxUrl><AjaxData>{''clientName'':''RDU'',''numberOfScreens'':''41''}</AjaxData><TagPrefix>\\10.10.101.34\Airport.RDU.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 1, DefaultIconType = 'Airport' WHERE Name = 'RDUTerm'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''1''}</AjaxData><TagPrefix>\\\\10.174.20.82\Airport.SLL.Term1.Zone1.Gate 1.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 2, DefaultIconType = 'Gate' WHERE Name = 'SLLGate001'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''2''}</AjaxData><TagPrefix>\\\\10.174.20.82\Airport.SLL.Term1.Zone1.Gate 2.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 3, DefaultIconType = 'Gate' WHERE Name = 'SLLGate002'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''3''}</AjaxData><TagPrefix>\\\\10.174.20.82\Airport.SLL.Term1.Zone1.Gate 3.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 4, DefaultIconType = 'Gate' WHERE Name = 'SLLGate003'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''4''}</AjaxData><TagPrefix>\\\\10.174.20.82\Airport.SLL.Term1.Zone1.Gate 4.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 5, DefaultIconType = 'Gate' WHERE Name = 'SLLGate004'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''5''}</AjaxData><TagPrefix>\\\\10.174.20.82\Airport.SLL.Term1.Zone1.Gate 5.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 6, DefaultIconType = 'Gate' WHERE Name = 'SLLGate005'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''6''}</AjaxData><TagPrefix>\\\\10.174.20.82\Airport.SLL.Term1.Zone1.Gate 6.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 7, DefaultIconType = 'Gate' WHERE Name = 'SLLGate006'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''7''}</AjaxData><TagPrefix>\\\\10.174.20.82\Airport.SLL.Term1.Zone1.Gate 7.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 8, DefaultIconType = 'Gate' WHERE Name = 'SLLGate007'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''8''}</AjaxData><TagPrefix>\\\\10.174.20.82\Airport.SLL.Term1.Zone1.Gate 8.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 9, DefaultIconType = 'Gate' WHERE Name = 'SLLGate008'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowNetwork</AjaxUrl><AjaxData>{''clientName'':''SLL''}</AjaxData><TagPrefix>\\\\10.174.20.82\Network.SLL.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 10, DefaultIconType = 'Network' WHERE Name = 'SLLNetwork'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Airport/Airport/ShowAirport</AjaxUrl><AjaxData>{''clientName'':''SLL'',''numberOfScreens'':''9''}</AjaxData><TagPrefix>\\\\10.174.20.82\Airport.SLL.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 1, DefaultIconType = 'Airport' WHERE Name = 'SLLTerm'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''10''}</AjaxData><TagPrefix>\\69.60.110.8\SouthWest.DAL.Term1.Zone1.Gate 10.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 1, DefaultIconType = 'Gate' WHERE Name = 'SWAGate10'
UPDATE Screens SET ScreenLayout = '<Screen-Layout Version="1.0.0"><AjaxUrl>/Gate/Gate/ShowGates</AjaxUrl><AjaxData>{''zoneNum'':''1'',''gateNum'':''12''}</AjaxData><TagPrefix>\\69.60.110.8\SouthWest.DAL.Term1.Zone1.Gate 12.</TagPrefix></Screen-Layout>', DefaultDisplayOrder = 2, DefaultIconType = 'Gate' WHERE Name = 'SWAGate12'