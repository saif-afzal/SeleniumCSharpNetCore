@ECHO OFF
rem for  %%b in ("DashBoardComplianceTest.bat" "DesinAndMiscTest.bat" "MachineLearningAndRecommendation.bat" "P1RecommendationAndContentTagTest.bat" "P1RegressionSectionManagementTest.bat" "P1RegressionTest2.bat" "P1RegressionTest8.bat" "PlaylistTest.bat" "RequiredTrainingTest.bat" "SectionManagementTest_NF.bat") do call %%b|| exit /b 1
call TestBatchFiles/DashBoardComplianceTest.bat
call TestBatchFiles/DesinAndMiscTest.bat
call TestBatchFiles/MachineLearningAndRecommendation.bat
call TestBatchFiles/P1RecommendationAndContentTagTest.bat
call TestBatchFiles/P1RegressionSectionManagementTest.bat
call TestBatchFiles/P1RegressionTest2.bat
call TestBatchFiles/P1RegressionTest8.bat
call TestBatchFiles/PlaylistTest.bat
call TestBatchFiles/RequiredTrainingTest.bat
call TestBatchFiles/SectionManagementTest_NF.bat'
call TestBatchFiles/P1RegressionTests.bat
