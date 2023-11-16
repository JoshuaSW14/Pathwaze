async function initService(dotnetHelper) {
    var foundPlaces = [];
    const displaySuggestions = function (predictions, status) {
        if (status != google.maps.places.PlacesServiceStatus.OK || !predictions) {
            alert(status);
            return;
        }

        predictions.forEach((prediction) => {
            if (!foundPlaces.includes(prediction.description)) {
                foundPlaces.push(prediction.description);
                dotnetHelper.invokeMethodAsync('AddSearch', prediction.description);
            }
        });
    };

    const myDiv = document.getElementById("popup-dropdown-search");
    const input = myDiv.querySelector("input");
    const service = new google.maps.places.AutocompleteService();

    input.addEventListener("input", function (e) {
        // Check if the input value is not null, not empty, and not just whitespace
        if (e.target.value && e.target.value.trim().length !== 0) {
            service.getQueryPredictions({ input: e.target.value }, displaySuggestions);
        } else {
            // Clear the suggestions and any other necessary state
            // Your logic to handle empty input goes here
            foundPlaces = [];
            //dotnetHelper.invokeMethodAsync('ClearSearch');
        }
    });
}

