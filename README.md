/****** SSMS 的 SelectTopNRows 命令的脚本  ******/
SELECT app.name,result.rulename,org.organcode,org.OrganName,details.Score,details.Weight,details.Comment
  FROM [Vote].[dbo].[AppAppraisementResults] as result left join vote.dbo.AppAppraisementResultScoreDetails as details on result.id=details.AppraisementResultId 
  left join vote.dbo.AppAppraisements as app on result.appraisementid=app.id
  left join vote.dbo.appcandidateorgunits as org on result.CandidateId=org.Id
  where result.Category=1 and org.OrganCode='00001.00012'
  order by org.OrganCode