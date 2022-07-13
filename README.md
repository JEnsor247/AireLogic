# AireLogicTechTest_JE
AireLogic Technical Test

The aim of the project is to connect to the MusicBrainz API and the Lyricsovh API to provide the user the ability to search for a music artist and return the average number of words that appear in their songs.

The project can be ran by building the solution and running the main executable file named "", there are no additional dependencies required.

The project has been built using the .NET Framework version 4.8

Due to using the Lyricsovh API there is a delay in bringing back results, and on occassion due to the number of calls that have been made to the API their will be no results returned from the query. In those instances the songs will not be added to the final count for calculating the average.

The MusicBrainz API is only able to bring back a certain number of results on each call, this has been handled by multiple calls where needed to the API and then using the offset to move along through the results. For this version the Artist Name is searched for using an exact match and only the first result is returned. 

*Future Improvements*

The application uses the standard CLI window for interaction and outputting of results, however this could be modified further if need be to utilise better graphical UI.

The delays on retrieving data are not ideal, given more time I would look at alternatives to the Lyricsovh API to improve performance.

The application has little unit testing, however it has been sanity checked by running the application end to end. Many of the tests would have been more integration tests than actual unit tests with the current state of the application
