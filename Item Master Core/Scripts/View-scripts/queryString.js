function parseSearchString(searchString) {
    var search = "test search String 001";
    var descriptionWords = [];
    var partialUPC;
    if (search != "" || search != null) {
        var searchWords = search.split(" ");

        if (searchWords.length != 0) {
            for (i = 0; i < searchWords.length; i++) {
                var substr = searchWords[i];
                if (parseInt(substr) == null || parseInt(substr) != null && substr.length <= 3) {
                    descriptionWords.push(substr);
                }
                else {
                    partialUPC = substr;
                }
            }
        }
    }
    
    var searchObject = {
        description: descriptionWords,
        upc: partialUpc
    };

    return searchObject;

}