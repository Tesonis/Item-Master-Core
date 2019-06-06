function parseSearchString(searchString) {
    var search = searchString;
    var descriptionWords = [];
    var partialUPC = "";
    if (search != "" || search != null) {
        var searchWords = search.split(" ");

        if (searchWords.length != 0) {
            for (i = 0; i < searchWords.length; i++) {
                var substr = searchWords[i];
                if (isNaN(parseInt(substr)) || ( !isNaN(parseInt(substr)) && substr.length <= 3)) {
                    descriptionWords.push(substr);
                }
                if (!isNaN(parseInt(substr)) && substr.length == 4) {
                    descriptionWords.push(substr);
                    partialUPC = substr;
                }
                else {
                    if (substr.length > partialUPC.length) {
                        descriptionWords.push(partialUPC);
                        partialUPC = substr;
                    }
                    else {
                        partialUPC = substr;
                    }
                    
                }
            }
        }
    }
    
    var searchObject = {
        description: descriptionWords,
        upc: partialUPC
    };

    return searchObject;

}