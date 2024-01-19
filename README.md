--计算总分排名
WITH TEMP AS (
SELECT RES.RuleName,ORG.OrganName,SUM(RES.Score)/COUNT(RES.RuleName) AS SCORE
FROM VOTE.DBO.AppAppraisements AS APP
LEFT JOIN VOTE.DBO.AppAppraisementResults AS RES ON APP.Id=RES.AppraisementId
LEFT JOIN VOTE.DBO.AppCandidateOrgUnits AS ORG ON RES.CandidateId=ORG.Id
WHERE RES.Category=1 AND APP.Id='845D2034-273C-004A-DE4D-3A0D38E325AD'
GROUP BY RES.RuleName,ORG.OrganName,ORG.Category)
SELECT TEMP.OrganName,SUM(TEMP.SCORE) FROM TEMP 
GROUP BY TEMP.OrganName

--获取评价内容
SELECT APP.Name AS 评测项目,RES.RuleName AS 评价主体,ORG.OrganName AS 被评价机构,DETAILS.Comment AS 评价附言
FROM VOTE.DBO.AppAppraisements AS APP 
LEFT JOIN VOTE.DBO.AppAppraisementResults AS RES ON APP.Id=RES.AppraisementId
LEFT JOIN VOTE.DBO.AppCandidateOrgUnits AS ORG ON RES.CandidateId=ORG.Id 
LEFT JOIN VOTE.DBO.AppAppraisementResultScoreDetails AS DETAILS ON RES.ID=DETAILS.AppraisementResultId
WHERE RES.Category=1 AND APP.Id='845D2034-273C-004A-DE4D-3A0D38E325AD'  AND DETAILS.Comment NOT IN ('',N'无')

--获取某一类行领导打分细项
select result.Score, result.RuleName,org.OrganName 
from vote.dbo.AppAppraisementResults result 
left join vote.dbo.AppCandidateOrgUnits org
 on result.CandidateId=org.Id 
 where AppraisementId='52F40FC0-A68B-014E-BA70-3A0FFF576870' 
 and RuleName =N'包头分行行长' order by result.Score desc